﻿using Microsoft.AspNetCore.Mvc;
using Eatech.Models;
using Eatech.Utilerias;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.Design;
using NuGet.Protocol.Plugins;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.PixelFormats;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NuGet.Versioning;


namespace Eatech.Controllers
{
    //controller pa admin y usuario
    [Authorize]
    public class PedidoController : Controller
    {
        //**************************************************************************************************************************************************************************//
        //contextos base de datos
        private readonly ContextoBD _context;
        public PedidoController(ContextoBD context)
        {
            _context = context;
        }
        //**************************************************************************************************************************************************************************//
        /*-Index donde se muestran el historial de pedidos-*/
        public IActionResult Index()
        {
            return View();
        }
        //**************************************************************************************************************************************************************************//
        /*-Apartado para crear el pedido + envio de correo por parte del cliente y admin-*/
        public IActionResult CrearPedido()
        {
            return View();
        }
        /*-Apartado para buscar alumnos antes del registro xd-*/

        /*-Task para crear pedido + enviar el correo de pedido creado-*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarPedido(Guid IdAlum, Guid IdCom, [Bind("pedido,FechaCPedido,FechaEntrega,NotaPedido,Estatus")] Bd_Pedido bd_Pedido, [Bind("pedido,IdAlumno")] BdI_Alu_Ped bdI_Alu_Ped, [Bind("IDComida,pedido")] BdI_Com_Ped bdI_Com_Ped)
        {
            if (ModelState.IsValid)
            {
                bd_Pedido.pedido = Guid.NewGuid();
                bd_Pedido.Estatus = "Generado";
                bdI_Com_Ped.IDComida = IdCom;
                bdI_Com_Ped.pedido = bd_Pedido.pedido;

                bdI_Alu_Ped.pedido = bd_Pedido.pedido;
                bdI_Alu_Ped.IdAlumno = IdAlum;
                /*-aqui va para poner el correo pa avisar del pedido creado-*/
                var ltam = User.Claims.FirstOrDefault(cc => cc.Type == "Email").Value;
                Utilerias.Correo.PedidoCorreo(ltam, "Pedido Creado", "Su pedido se ha generado exitosamente." + " \nEl estado de su pedido es: " + bd_Pedido.Estatus + " \n Eatech");

                _context.Add(bdI_Alu_Ped);
                _context.Add(bdI_Com_Ped);
                _context.Add(bd_Pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(bd_Pedido);
        }
        /*-*/


        //**************************************************************************************************************************************************************************//
        /*-Apartado para editar el estatus del pedido por parte del admin + envio de correo al cliente para -*/
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditarPedido(Guid? Id)
        {
            if (Id == null || _context.Pedidos == null) return NotFound();
            var ltam = await _context.Pedidos.FindAsync(Id);
            if (ltam == null) return NotFound();
            return View(ltam);
        }

        /*-Task para moificar el pedido-*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarEstatus(Guid ID, [Bind("Estatus")] Bd_Pedido bd_pedido)
        {
            if (ID != bd_pedido.pedido) return NotFound();
            try
            {
                _context.Update(bd_pedido);
                await _context.SaveChangesAsync();
                var ltam = User.Claims.FirstOrDefault(cc => cc.Type == "Email").Value;
                Utilerias.Correo.PedidoCorreo(ltam, "Estatus del pedido", "El estatus de su pedido se ha actualizado." + " \nEl estado de su pedido es: " + bd_pedido.Estatus + " \n Eatech");

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoEx(bd_pedido.pedido)) return NotFound();
                else throw;
            }
            return View(bd_pedido);
        }

        /*-pedido Existente-*/
        private bool PedidoEx(Guid id)
        {
            return (_context.Pedidos?.Any(licerv => licerv.pedido == id)).GetValueOrDefault();
        }

        //**************************************************************************************************************************************************************************//
        /*-Apartado para eliminar pedidos mayores a 1 año para ahorrar almacenamiento en la base de datos [Solo admin]-*/
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EliminarPedidos(Guid? Id)
        {
            if (Id == null || _context.Pedidos == null) return NotFound();
            var ltam = await _context.Pedidos.FindAsync(Id);
            if (ltam == null) return NotFound();
            return View(ltam);
        }

        /*-Task para eliminar de la base de datos los pedidos-*/
        public async Task<IActionResult> ConfirmarPedido(Guid id)
        {
            if (id == null || _context.Pedidos == null) return Problem("El pedido no existe");
            var ltam = await _context.Intermedia_Comida_Pedi.FindAsync(id);
            var lcv = await _context.Intermedia_Alum_Pedi.FindAsync(id);
            var cc = await _context.Pedidos.FindAsync(id);
            if (ltam != null && lcv != null && cc != null)
            {
                _context.Intermedia_Comida_Pedi.Remove(ltam);
                _context.Intermedia_Alum_Pedi.Remove(lcv);
                _context.Pedidos.Remove(cc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //**************************************************************************************************************************************************************************//
        /*-Apartado para ver el pedido de manera individual-*/
        public IActionResult PedidoDashboard(Guid? id)
        {
            if (id == null || _context.Pedidos == null) return NotFound();
            var lgc = _context.Pedidos.Where(ltam => ltam.pedido == id);
            if (lgc == null) return NotFound();
            return View(lgc);
        }

        //**************************************************************************************************************************************************************************//
        /*-apartado vistas de admin [dashboard, etc]-*/
    }
}
