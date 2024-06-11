using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eatech.Models;
using Eatech.Utilerias;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.Design;
using NuGet.Protocol.Plugins;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Storage;
using Grpc.Core;

namespace Eatech.Controllers
{
    //Apartado en su mayoria para admin
    [Authorize]
    public class EscuelaController : Controller
    {
        //**************************************************************************************************************************************************************************//
        //contextos base de datos
        private readonly ContextoBD _context;
        public EscuelaController(ContextoBD context)
        {
            _context = context;
        }


        //**************************************************************************************************************************************************************************//
        /*-apartado para visualizar los datos de la escuela -*/
        public async Task<IActionResult> Index()
        {
            var ltam = Guid.Parse(User.Claims.FirstOrDefault(cc => cc.Type == "Id").Value);

            var sopadepapa = _context.Intermedia_Usuario_Escuela.Include(l => l.Escuela).Include(g => g.Usuario).Where(c => c.IdUsuario == ltam);
            return View(await sopadepapa.ToListAsync());
        }
        //**************************************************************************************************************************************************************************//
        /*-Apartado para registrar la escuela + generar un guid de invitacion para vincular al usuario con la esta cosa-*/
        public IActionResult RegistrarEscuela()
        {
            return View();
        }

        /*-Task para registrar una escuela nueva -*/
        public async Task<IActionResult> RegistrarEscuela([Bind("IdEscuela,ClaveEscuela,Nombre,Codigo")] Bd_Escuela bd_Escuela)
        {
            if (ModelState.IsValid)
            {
                bd_Escuela.IdEscuela = Guid.NewGuid();
                _context.Add(bd_Escuela);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(bd_Escuela);
        }

        /*-Task para verificar si la clave de la escuela ya existe-*/



        //**************************************************************************************************************************************************************************//
        /*-Apartado para ver la lista de la usuarios vinculados a la escuelonchaponcha (Esta es solo las vistas del admin)-*/
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> UsuariosVinculados(Guid? Id)
        {
            var ltam = _context.Intermedia_Usuario_Escuela.Include(l => l.Usuario).Include(g => g.Escuela).Where(c => c.IdEscuela == Id);
            return View(ltam);
        }

        //**************************************************************************************************************************************************************************//
        /*-Apartado para eliminar usuarios/Escuela de la bd-*/
        public async Task<IActionResult> EliminarEscuela(Guid? Id)
        {
            if (Id == null || _context.Escuela == null) return NotFound();
            var ltam = _context.Intermedia_Usuario_Escuela.Include(l => l.Escuela).Include(g => g.Usuario).Where(c => c.IdEscuela == Id);
            if (ltam == null) return NotFound();
            return View(ltam);
        }

        /*-task para eliminar de la base de datos la escuela-*/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarEscuelaConfirmar(Guid Id)
        {
            if (Id == null || _context.Escuela == null) return Problem("Escuela no encontrada");
            var ltam = await _context.Escuela.FindAsync(Id);
            var lgc = await _context.Intermedia_Usuario_Escuela.FindAsync(Id);
            if (ltam != null && lgc != null)
            {
                _context.Intermedia_Usuario_Escuela.Remove(lgc);
                _context.Escuela.Remove(ltam);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //**************************************************************************************************************************************************************************//
        /*-Apartado para editar las cosas de la escuela menos el codigo de invitacion  (Vista para solo Admins)-*/
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditarEscuela(Guid? Id)
        {
            if (Id == null || _context.Escuela == null) return NotFound();
            var ltam = await _context.Escuela.FindAsync(Id);
            if (ltam == null) return NotFound();
            return View(ltam);
        }

        /*-Task para modificar los datos en la base de datos, en la tabla de escuela-*/
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditarEscuela(Guid iD, [Bind("ClaveEscuela,Nombre")] Bd_Escuela bd_Escuela)
        {
            if (iD != bd_Escuela.IdEscuela) return NotFound();

            try
            {
                _context.Update(bd_Escuela);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscuelaEx(bd_Escuela.IdEscuela)) return NotFound();
                else throw;
            }
            return View(bd_Escuela);
        }

        /*-Verificar si existe la escuela-*/
        private bool EscuelaEx(Guid Id)
        {
            return (_context.Escuela?.Any(mfvm => mfvm.IdEscuela == Id)).GetValueOrDefault();
        }

        //**************************************************************************************************************************************************************************//
        /*-admin vistas plus-*/
    }
}
