using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eatech.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;


namespace Eatech.Controllers
{
    //Apartado en su mayoria para admin
    [Authorize]
    public class EscuelaController : Controller
    {
        ////**************************************************************************************************************************************************************************//
        ////contextos base de datos
        //private readonly ContextoBD _context;
        //public EscuelaController(ContextoBD context)
        //{
        //    _context = context;
        //}


        ////**************************************************************************************************************************************************************************//
        ///*-apartado para visualizar los datos de la escuela -*/
        //public async Task<IActionResult> Index()
        //{
        //    var ltam = Guid.Parse(User.Claims.FirstOrDefault(cc => cc.Type == "Id").Value);

        //    var sopadepapa = _context.Intermedia_Usuario_Escuela.Include(l => l.Escuela).Include(g => g.Usuario).Where(c => c.IdUsuario == ltam);
        //    return View(await sopadepapa.ToListAsync());
        //}
        ////**************************************************************************************************************************************************************************//
        ///*-Apartado para registrar la escuela + generar un guid de invitacion para vincular al usuario con la esta cosa-*/
        //[Authorize(Roles = "Admin")]
        //public IActionResult RegistrarEscuela()
        //{
        //    return View();
        //}

        ///*-Task para registrar una escuela nueva -*/
        //public async Task<IActionResult> RegistrarEscuela([Bind("IdEscuela,ClaveEscuela,Nombre,Codigo")] Bd_Escuela bd_Escuela)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bd_Escuela.IdEscuela = Guid.NewGuid();
        //        bd_Escuela.ClaveEscuela = EscuelaController.GenerarClaveEscuela();
        //        _context.Add(bd_Escuela);
        //        var ltam = User.Claims.FirstOrDefault(cc => cc.Type == "Email").Value;
        //        Utilerias.Correo.EscuelaCorreo(ltam, "Registro de Escuela", "Su escuela ha sido regisrtrada exitosamente." + " \nla clave de su escuela es: " + bd_Escuela.ClaveEscuela + " \n Eatech");
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(bd_Escuela);
        //}

        ///*-Task para verificar si la clave de la escuela ya existe-*/
        //[AllowAnonymous]
        //public IActionResult ValidarCodigoEscuela(string ClaveEscuela)
        //{
        //    var busqueda = _context.Escuela.FirstOrDefault(Li => Li.ClaveEscuela == ClaveEscuela);
        //    if (busqueda == null) return Ok(true);
        //    return Ok(false);
        //}



        ////**************************************************************************************************************************************************************************//
        ///*-Apartado para ver la lista de la usuarios vinculados a la escuelonchaponcha (Esta es solo las vistas del admin)-*/
        //[Authorize(Roles = ("Admin"))]
        //public async Task<IActionResult> UsuariosVinculados(Guid? Id)
        //{
        //    var ltam = _context.Intermedia_Usuario_Escuela.Include(l => l.Usuario).Include(g => g.Escuela).Where(c => c.IdEscuela == Id);
        //    return View(ltam);
        //}

        ////**************************************************************************************************************************************************************************//
        ///*-Apartado para eliminar usuarios/Escuela de la bd-*/
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> EliminarEscuela(Guid? Id)
        //{
        //    if (Id == null || _context.Escuela == null) return NotFound();
        //    var ltam = _context.Intermedia_Usuario_Escuela.Include(l => l.Escuela).Include(g => g.Usuario).Where(c => c.IdEscuela == Id);
        //    if (ltam == null) return NotFound();
        //    return View(ltam);
        //}

        ///*-task para eliminar de la base de datos la escuela-*/
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EliminarEscuelaConfirmar(Guid Id)
        //{
        //    if (Id == null || _context.Escuela == null) return Problem("Escuela no encontrada");
        //    var ltam = await _context.Escuela.FindAsync(Id);
        //    var lgc = await _context.Intermedia_Usuario_Escuela.FindAsync(Id);
        //    if (ltam != null && lgc != null)
        //    {
        //        _context.Intermedia_Usuario_Escuela.Remove(lgc);
        //        _context.Escuela.Remove(ltam);
        //    }
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        ////**************************************************************************************************************************************************************************//
        ///*-Apartado para editar las cosas de la escuela menos el codigo de invitacion  (Vista para solo Admins)-*/
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> EditarEscuela(Guid? Id)
        //{
        //    if (Id == null || _context.Escuela == null) return NotFound();
        //    var ltam = await _context.Escuela.FindAsync(Id);
        //    if (ltam == null) return NotFound();
        //    return View(ltam);
        //}

        ///*-Task para modificar los datos en la base de datos, en la tabla de escuela-*/
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditarEscuela(Guid iD, [Bind("ClaveEscuela,Nombre")] Bd_Escuela bd_Escuela)
        //{
        //    if (iD != bd_Escuela.IdEscuela) return NotFound();

        //    try
        //    {
        //        _context.Update(bd_Escuela);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EscuelaEx(bd_Escuela.IdEscuela)) return NotFound();
        //        else throw;
        //    }
        //    return View(bd_Escuela);
        //}

        ///*-Verificar si existe la escuela-*/
        //private bool EscuelaEx(Guid Id)
        //{
        //    return (_context.Escuela?.Any(mfvm => mfvm.IdEscuela == Id)).GetValueOrDefault();
        //}

        ////**************************************************************************************************************************************************************************//
        ///*-admin vistas plus-*/

        ///*-Proceso para crear la clave de vinculacion Escuela-Usuario-*/
        //public static string GenerarClaveEscuela(int longitud = 7)
        //{
        //    const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        //    var bytes = new byte[longitud];

        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(bytes);
        //    }

        //    var clave = new char[longitud];
        //    for (int i = 0; i < longitud; i++)
        //    {
        //        clave[i] = caracteresPermitidos[bytes[i] % caracteresPermitidos.Length];
        //    }

        //    return new string(clave);
        //}
    }
}
