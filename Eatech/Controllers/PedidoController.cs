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
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NuGet.Versioning;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


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
            ViewBag.comidavb = _context.Comidas.ToList();

            ViewBag.alumno = _context.Alumnos.ToList();
            return View();


        }
        /*-Apartado para buscar alumnos antes del registro xd-*/

        /*-Task para crear pedido + enviar el correo de pedido creado-*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarPedido(string nombrealum, string nombrecomida, [Bind("pedido,FechaCPedido,FechaEntrega,NotaPedido,Estatus")] Bd_Pedido bd_Pedido)
        {
            if (ModelState.IsValid)
            {
                BdI_Alu_Ped bdI_Alu_Ped = new BdI_Alu_Ped();
                bd_Pedido.pedido = Guid.NewGuid();
                bd_Pedido.Estatus = "Generado";
                bd_Pedido.FechaCPedido= DateTime.Now;
                bd_Pedido.NotaPedido = ".";
                _context.Add(bd_Pedido);

                await _context.SaveChangesAsync();

                var buscarcomida = _context.Comidas.FirstOrDefault(lgc => lgc.Nombre == nombrecomida);


                buscarcomida.PorcionesDisponibles = buscarcomida.PorcionesDisponibles - 1;
                BdI_Com_Ped bdI_Com_Ped = new BdI_Com_Ped();
                bdI_Com_Ped.IDComida = buscarcomida.IDComida;
                bdI_Com_Ped.pedido = bd_Pedido.pedido;
                _context.Update(buscarcomida);
                _context.Add(bdI_Com_Ped);
                await _context.SaveChangesAsync();

                var idClaim = User.Claims.FirstOrDefault(lili => lili.Type == "Id");
                Guid id;
                if (!Guid.TryParse(idClaim.Value, out id)) return NotFound("Id de usuario no válido.");

                var buscaralumno = _context.Alumnos.FirstOrDefault(a => _context.Intermedia_Usuario_Alumno.Any(ii => ii.IdUsuario == id && ii.IdAlumno == a.IdAlumno) && a.Nombre == nombrealum);
                bdI_Alu_Ped.pedido = bd_Pedido.pedido;
                bdI_Alu_Ped.IdAlumno = buscaralumno.IdAlumno;

                /*-aqui va para poner el correo pa avisar del pedido creado-*/
                var ltam = User.FindFirst(ClaimTypes.Email).Value.ToString();
                Utilerias.Correo.PedidoCorreo(ltam, "Pedido Creado", "Su pedido se ha generado exitosamente." + " \nEl estado de su pedido es: " + bd_Pedido.Estatus + " \n Eatech");

                _context.Add(bdI_Alu_Ped);

                await _context.SaveChangesAsync();
                return RedirectToAction("CrearPedido","Pedido");

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
                var ltam = User.FindFirst(ClaimTypes.Email).Value.ToString();
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
        [Authorize(Roles = "Usuario, Admin")]
        public async Task<IActionResult> PedidoDashboard()
        {

            ViewBag.comidavv = _context.Comidas.ToList();

            ViewBag.alumno = _context.Alumnos.ToList();

            var id = Guid.Parse(User.Claims.FirstOrDefault(lili => lili.Type == "Id").Value);
            if (id == null || _context.Pedidos == null) return NotFound();
            var lgc = _context.Pedidos.Where(ltam => ltam.pedido == id);

            if (lgc == null) return NotFound();
            var comi = await _context.Pedidos./*Where(pedido => _context.Intermedia_Comida_Pedi.Any(inter => inter.IDcomida = id && inter.id = pedido.id)).*/ToListAsync();
            return View(comi);
        }

        //return View(alumnos);
        //**************************************************************************************************************************************************************************//
        /*-apartado vistas de admin [dashboard, etc]-*/

        [Authorize(Roles = "Usuario")]
        public async Task <IActionResult> Buscar(string AlumnoMatricula)
        {
            var userId = User.Identity.Name;
            var padre = Guid.Parse(User.Claims.FirstOrDefault(p => p.Type == "Id").Value);


            if (padre == null)
            {
                return NotFound("Padre no encontrado.");
            }

            var alumnos = _context.Intermedia_Usuario_Alumno.Where(a => a.IdAlumno == padre).Select(a => a.Idalumno).ToList(); /*Guid.Parse(User.Claims.FirstOrDefault(p => p.Type == "Id").Value)); padre.GetType == "Id");.ToList();*/

            var alumno = alumnos.FirstOrDefault(a => a.NoMatricula == AlumnoMatricula);

            if (alumno == null)
            {
                return NotFound("Alumno no encontrado.");
            }

            var pedidoIds = _context.Intermedia_Alum_Pedi.Where(pi => pi.Idalumno == alumno.IdAlumno).Select(pi => pi.PedidoId).ToList();


            var pedidos = _context.Pedidos.Where(p => pedidoIds.Contains(p.pedido)).Select(p => new ViewModels.PedidoViewModel
                         {
                             AlumnoNombre = alumno.Nombre,
                             AlimentoNombre = _context.Comidas.FirstOrDefault(c => c.IDComida == p.pedido)?.Nombre,
                             FechaPedido = p.FechaCPedido,
                             FechaEntrega = p.FechaEntrega,
                             EstatusPedido = p.Estatus
                         })
                         .ToList();

            ViewBag.Pedidos = pedidos;
            return View();
        }
    }
}


//var usuID = User.Identity.Name;
//var id = Guid.Parse(User.Claims.FirstOrDefault(lili => lili.Type == "Id").Value);
//if (id == null || _context.Pedidos == null) return NotFound();

//var alumnos = Guid.Parse(_context.Usuarios.Where(lili => lili.IdUsuario = AlumnoMatricula)).ToList();



//var lgc = _context.Pedidos.Where(ltam => ltam.pedido == id);


//return View(Buscar);









//BdI_Alu_Ped bdI_Alu_Ped = new BdI_Alu_Ped();
////Bd_Alumno bd_alu = new Bd_Alumno();
//var claims = new List<Claim> {

//    new Claim("Id", Idalumno.ToString()),
//};

//var userId = User.Identity.Name; 
//var padre = Guid.Parse(User.Claims.FirstOrDefault(p => p.Type == "Id").Value);

//if (padre == null)
//{
//    return NotFound("Padre no encontrado.");
//}

//var alumnos = _context.Alumnos.Where(a => a.IdAlumno == Guid.Parse(User.Claims.FirstOrDefault(p => p.Type == "Id").Value)); /*padre.GetType == "Id");.ToList();*/


//var alumno = alumnos.FirstOrDefault(a => a.NoMatricula == AlumnoMatricula);

//if (alumno == null)
//{
//    return NotFound("Alumno no encontrado.");
//}



//var pedidoIds = _context.Intermedia_Alum_Pedi.Where(ip => ip.Idalumno = alumnos.).Select(ip => ip.PedidoId).ToList();


//var pedidos = _context.Intermedia_Alum_Pedi.Where(p => Guid.Parse(bdI_Alu_Ped.Pedido) == Guid.Parse(bd_alu.IdAlumno);/*bd_alu.IdAlumno == alumno.NoMatricula).Select(p => new PedidoViewModel*/
//    {
//        AlumnoNombre = alumno.Nombre,
//        AlimentoNombre = _context.Comidas.FirstOrDefault(a => a.Id == p.AlimentoId).Nombre,
//        FechaPedido = p.FechaPedido,
//        FechaEntrega = p.FechaEntrega,
//        EstatusPedido = p.Estatus
//    })
//    .ToList();

//ViewBag.Pedidos = pedidos;