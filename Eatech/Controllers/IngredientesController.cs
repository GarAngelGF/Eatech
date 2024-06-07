using Microsoft.AspNetCore.Mvc;

namespace Eatech.Controllers
{
    public class IngredientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
