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
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components.Web;

namespace Eatech.Controllers
{
    [Authorize]
    //Nota: La mayoria de este controller va a ser accesible para los admin :o
    public class ComidaController : Controller
    {
        //**************************************************************************************************************************************************************************//
        //contextos base de datos
        private readonly ContextoBD _context;
        public ComidaController(ContextoBD context)
        {
            _context = context;
        }
        //**************************************************************************************************************************************************************************//
        /*-Index con el menu de la comida disponible-*/
        public async Task<IActionResult> Index()
        {
            var lid = Guid.Parse(User.Claims.FirstOrDefault(lili => lili.Type == "Id").Value);

            var LContexto = _context.Intermedia_Usuario_Alumno.Include(li => li.alumno).Include(gzl => gzl.usuario).Where(cerv => cerv.IdUsuario == lid);
            return View(await LContexto.ToListAsync());
        }

        //Crud papayadecelayafifirisfraissopadepapasuperpaposaespiromastoreiclo
        //**************************************************************************************************************************************************************************//
        /*-Apartado para todo sobre el crear comida-*/
        public IActionResult RegistrarComida()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarComida([Bind("IDComida,Nombre,Porciones,PorcionesDisponibles")] Bd_Comida bd_comida, [Bind("IDComida,IdIngrediente")] BdI_Com_Ingr bdI_Com_Ingr, Guid IdIngradiente)
        {
            if (ModelState.IsValid)
            {
                bd_comida.IDComida = Guid.NewGuid();
                var buscador = _context.Ingredientes.FirstOrDefault(lgc => lgc.IdIngrediente == IdIngradiente);
                Guid Sopadepapa;
                //bdI_Com_Ingr.IdIngrediente = Guid.Parse(_context.Ingredientes.First(lgc => lgc.IdIngrediente == IdIngradiente));
            }

            return View(bd_comida);
        }

        //**************************************************************************************************************************************************************************//
        /*-Apartado para detalles de la comida-*/
        public IActionResult ComidaDashboard(Guid? id)
        {
            if (id == null || _context.Alumnos == null) return NotFound();
            var lgc = _context.Intermedia_Comida_Ingre.Include(l => l.Comida).Include(g => g.Ingredientes).Where(c => c.IDComida == id);
            if (lgc == null) return NotFound();
            return View(lgc);
        }


        //**************************************************************************************************************************************************************************//
        /*-Apartado para Editar la comida-*/
        public async Task<IActionResult> EditarComida(Guid? Id)
        {
            if (Id == null || _context.Comidas == null) return NotFound();
            var lgc = await _context.Comidas.FindAsync(Id);
            if (lgc == null) return NotFound();
            return View(lgc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarComida(Guid id, [Bind("Nombre,Porciones,PorcionesDisponibles")] Bd_Comida bd_Comida)
        {
            if (id != bd_Comida.IDComida) return NotFound();

            try
            {
                _context.Update(bd_Comida);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComidaEx(bd_Comida.IDComida)) return NotFound();
                else throw;
            }
            return View(bd_Comida);
        }

        private bool ComidaEx(Guid Id)
        {
            return (_context.Comidas?.Any(lgc => lgc.IDComida == Id)).GetValueOrDefault();
        }


        //**************************************************************************************************************************************************************************//
        /*-Apartado para eliminar la comida-*/


        //**************************************************************************************************************************************************************************//
        /*-Admin Dashboard-*/
        //**************************************************************************************************************************************************************************//
        /*--*/

    }
}
