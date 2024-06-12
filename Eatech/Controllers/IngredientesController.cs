using Microsoft.AspNetCore.Mvc;
using Eatech.Models;
using Microsoft.AspNetCore.Authorization;


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

        [Authorize (Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        }

        /*-Apartado para la vista y task para agregar un ingrediente-*/

        /*-Apartado para Editar un ingrediente-*/

        /*-Apartado para los detalles de un ingrediente -*/

        /*-Apartado para eliminar un ingrediente -*/

        /*--*/

        /*--*/

        /*--*/

        /*--*/

       
    }
}
