using Microsoft.AspNetCore.Mvc;
using Eatech.Models;
using Microsoft.AspNetCore.Authorization;
using SixLabors.ImageSharp;
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore;


namespace Eatech.Controllers
{
    [Authorize]// todas las vistas de admin
    public class IngredientesController : Controller
    {
        //**************************************************************************************************************************************************************************//
        //contextos base de datos
        private readonly ContextoBD _context;
        public IngredientesController(ContextoBD context)
        {
            _context = context;
        }
        //**************************************************************************************************************************************************************************//
        /*-Index con los ingredientes disponible (solo admin)-*/

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }


        //**************************************************************************************************************************************************************************//
        /*-Apartado para la vista y task para agregar un ingrediente-*/
        [Authorize(Roles = "Admin")]
        public IActionResult AgregarIngrediente()
        {
            return View();
        }

        /*-task para agregar a la base de datos los ingredientes-*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarIngrediente([Bind("IdIngrediente, Nombre,Tipo")] Bd_Ingredientes bd_Ingredientes)
        {
            if (ModelState.IsValid)
            {
                bd_Ingredientes.IdIngrediente = Guid.NewGuid();
                _context.Add(bd_Ingredientes);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(bd_Ingredientes);
        }
        [Authorize (Roles ="Admin")]
        public IActionResult ValidarIngredientes(string Nombre)
        {
            var busqueda = _context.Ingredientes.FirstOrDefault(Li => Li.Nombre == Nombre);
            if (busqueda == null) return Ok(true);
            return Ok(false);
        }


        //**************************************************************************************************************************************************************************//
        /*-Apartado para Editar un ingrediente-*/
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditarIngrediente(Guid? Id)
        {
            if (Id == null || _context.Ingredientes == null) return NotFound();
            var ltam = await _context.Ingredientes.FindAsync(Id);
            if (ltam == null) return NotFound();
            return View(ltam);
        }

        /*-Task para editar el ingrediente en la base de datos-*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarIngredientes(Guid Id, [Bind("Nombre,Tipo")] Bd_Ingredientes bd_Ingredientes)
        {
            if (Id != bd_Ingredientes.IdIngrediente) return NotFound();
            try
            {
                _context.Update(bd_Ingredientes);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredienteEx(bd_Ingredientes.IdIngrediente)) return NotFound();
                else throw;
            }

            return View();
        }

        /*-bool para verificar existencia del ingrediente-*/
        private bool IngredienteEx(Guid id)
        {
            return (_context.Ingredientes?.Any(ltam => ltam.IdIngrediente == id)).GetValueOrDefault();
        }

        //**************************************************************************************************************************************************************************//
        /*-Apartado para los detalles de un ingrediente -*/
        [Authorize(Roles = "Admin")]
        public IActionResult DetallesIngrediente()
        {
            return View();
        }


        //**************************************************************************************************************************************************************************//
        /*-Apartado para eliminar un ingrediente -*/
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EliminarIngrediente(Guid? Id)
        {
            if (Id == null || _context.Ingredientes == null) return NotFound();
            var LContexto = _context.Intermedia_Usuario_Alumno.Where(cerv => cerv.IdUsuario == Id);
            if (LContexto == null) return NotFound();
            return View(LContexto);
        }

        /*-Task para eliminar de la base de datos al pobre ingrediente pipipipipi-*/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminarIngrediente(Guid id)
        {
            if (id == null || _context.Ingredientes == null) return Problem("Ingrediente no encontrado");
            var Ltam = await _context.Ingredientes.FindAsync(id);
            var lili = await _context.Intermedia_Comida_Ingre.FindAsync(id);


            if (Ltam != null && lili != null)
            {
                _context.Intermedia_Comida_Ingre.Remove(lili);
                _context.Ingredientes.Remove(Ltam);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        /*--*/



    }
}
