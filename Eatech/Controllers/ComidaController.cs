using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eatech.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization.Infrastructure;


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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var lid = Guid.Parse(User.Claims.FirstOrDefault(lili => lili.Type == "Id").Value);

           // var LContexto = _context.Intermedia_Usuario_Alumno.Include(li => li.alumno).Include(gzl => gzl.usuario).Where(cerv => cerv.IdUsuario == lid);
            return View();
        }

        //Crud papayadecelayafifirisfraissopadepapasuperpaposaespiromastoreiclo
        //**************************************************************************************************************************************************************************//
        /*-Apartado para todo sobre el crear comida-*/
        [Authorize(Roles = "Admin")]
        public IActionResult RegistrarComida()
        {
            return View();
        }

        /*-Tasl para registrar la comida en la base de datos conectada con azure sopadepapap-*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarComida([Bind("IDComida,Nombre,Porciones,PorcionesDisponibles,Visibilidad")] Bd_Comida bd_comida)
        {
            bd_comida.Visibilidad = "visible";
            bd_comida.PorcionesDisponibles = bd_comida.Porciones;
           

            if (ModelState.IsValid)
            {
             
                bd_comida.IDComida = Guid.NewGuid();
                
                _context.Add(bd_comida);
                await _context.SaveChangesAsync();
                return RedirectToAction("RegistrarComida", "Comida");

            }

            return View(bd_comida);
        }

        /*-validar que no se repita el nombre de la comida-*/
        [AllowAnonymous]
        public IActionResult ValidarComida(string Nombre)
        {
            var busqueda = _context.Comidas.FirstOrDefault(Li => Li.Nombre == Nombre);
            if (busqueda == null) return Ok(true);
            return Ok(false);
        }



        //**************************************************************************************************************************************************************************//
        /*-Apartado para detalles de la comida-*/

        [Authorize(Roles = "Usuario,Admin")]
        
        public IActionResult ComidaDashboard()
        {
            var id = Guid.Parse(User.Claims.FirstOrDefault(lili => lili.Type == "Id").Value);
            if (id == null || _context.Alumnos == null) return NotFound();
            

            return View();
        }


        //**************************************************************************************************************************************************************************//
        /*-Apartado para Editar la comida-*/
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditarComida(Guid? Id)
        {
            if (Id == null || _context.Comidas == null) return NotFound();
            var lgc = await _context.Comidas.FindAsync(Id);
            if (lgc == null) return NotFound();
            return View(lgc);
        }

        /*-Task para editar los datos de la comida-*/
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


        /*-Comprueba si el id de la comida existe o nelsonmandela-*/
        private bool ComidaEx(Guid Id)
        {
            return (_context.Comidas?.Any(lgc => lgc.IDComida == Id)).GetValueOrDefault();
        }


        //**************************************************************************************************************************************************************************//
        /*-Apartado para eliminar la comida-*/
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EliminarComida(Guid? Id)
        {
            if (Id == null || _context.Comidas == null) return NotFound();
          
            return View();
        }

        /*-task para mandar con papa dio los valores de la comida :o -*/
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminarComida(Guid id)
        {
            if (id == null || _context.Alumnos == null) return Problem("Alumno no encontrado");
            var ltam = await _context.Comidas.FindAsync(id);
            var lgc = await _context.Intermedia_Comida_Pedi.FindAsync(id);
            
            if (lgc != null && ltam != null )
            {
              
                _context.Intermedia_Comida_Pedi.Remove(lgc);
                _context.Comidas.Remove(ltam);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        //**************************************************************************************************************************************************************************//
        /*-Admin Dashboard-*/
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminComidaDashboard()
        {
            return View();
        }

        //**************************************************************************************************************************************************************************//
        /*-Remote para validar porciones disponibles-*/
        [AllowAnonymous]
        public IActionResult ValidarPorcionesDisponibles(Guid? ID)
        {
            var busqueda = _context.Comidas.FirstOrDefault(Li => Li.IDComida == ID);

            if (busqueda.Porciones > busqueda.PorcionesDisponibles) return Ok(true);
            return Ok(false);
        }




        /**************************************************************************************************************************************************************************/
        [Authorize(Roles = "Usuario")]
        public IActionResult PedirComida()
        {
         
            return View();
        }


        /**************************************************************************************************************************************************************************/


    }
}
