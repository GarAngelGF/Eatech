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
using Microsoft.AspNetCore.Mvc.Filters;


namespace Eatech.Controllers
{
    [Authorize]
    public class AplicacionController : Controller
    {
        //**************************************************************************************************************************************************************************//
        //contextos base de datos
        private readonly ContextoBD _context;

        public string? Rolselect { get; private set; }

        public AplicacionController(ContextoBD context)
        {
            _context = context;
        }
        //**************************************************************************************************************************************************************************//

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }





        //**************************************************************************************************************************************************************************//
        //Apartado para poner todo lo referente a login y al logout
        [AllowAnonymous]
        public IActionResult Login(string? error)
        {


            ViewBag.error = error;
            return View();
        }

        /*-para validar el usuario-*/
        [AllowAnonymous]
        public async Task<IActionResult> VerificarUsu(string correo, string contrasena)
        {
            var busqueda = _context.Usuarios.FirstOrDefault(Li => Li.Correo == correo);
            if (busqueda == null) return RedirectToAction("Login", new { error = true });
            if (!Encriptar.VerifyHash(contrasena, busqueda.Contrasena)) return RedirectToAction("Login", new { error = true });

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, busqueda.Nombre),
                new Claim(ClaimTypes.Role, busqueda.Rol),
                new Claim(ClaimTypes.Email, busqueda.Correo),
                new Claim("Id", busqueda.IdUsuario.ToString()),
            };
            var userIdentity = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);

            if (busqueda.Rol == "Usuario") return RedirectToAction("Dashboard");

            return RedirectToAction("AdminDashboard");
        }

        /*-Logout-*/
        public async Task<IActionResult> Logout()

        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Aplicacion");
        }



        //**************************************************************************************************************************************************************************//
        //Apartado para poner todo lo referente al registro del usuario
        [AllowAnonymous]
        public IActionResult Registro()
        {
            return View();
        }

        /*-Apartado donde se registra el usuario y admin en la base de datos-*/

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Registro([Bind("IdUsuario,Correo,Contrasena,Nombre,aPaterno,aMaterno,FechaCreacion,TokenDRestauracion,CaducidadToken,intentos,Rol")] Bd_Usuario bd_Usuario)
        {



            bd_Usuario.Contrasena = Encriptar.HashString(bd_Usuario.Contrasena);
            bd_Usuario.Rol = "Usuario";
            bd_Usuario.FechaCreacion = DateTime.Now;

            if (ModelState.IsValid)
            {

                bd_Usuario.IdUsuario = Guid.NewGuid();
                _context.Add(bd_Usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Login));

               
                    TempData["Message"] = "Registro exitoso";
                    return RedirectToAction("Index", "Home");
                

            }
            return View(bd_Usuario);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistroAdmin([Bind("IdUsuario,Correo,Contrasena,Nombre,FechaCreacion,TokenDRestauracion,CaducidadToken,intentos,Rol")] Bd_Usuario bd_Usuario)
        {
            bd_Usuario.Contrasena = Encriptar.HashString(bd_Usuario.Contrasena);
            bd_Usuario.Rol = "Admin";
            bd_Usuario.FechaCreacion = DateTime.Now;
            bd_Usuario.aPaterno = "No aplica";
            bd_Usuario.aMaterno = "No aplica";

            ModelState.Remove("aPaterno");
            ModelState.Remove("aMaterno");

            if (ModelState.IsValid)
            {
                bd_Usuario.IdUsuario = Guid.NewGuid();
                _context.Add(bd_Usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Login));
            }

            return View(bd_Usuario);
        }

        /*-Validar que no se repita el correo-*/
        [AllowAnonymous]
        public IActionResult ValidarCorreoUnico(string correo)
        {
            var busqueda = _context.Usuarios.FirstOrDefault(Li => Li.Correo == correo);
            if (busqueda == null) return Ok(true);
            return Ok(false);
        }


        //**************************************************************************************************************************************************************************//
        //Apartado vista Cambiar/ Recuperar Contraseña contraseña
        [AllowAnonymous]
        public IActionResult RecuperarContrasena()
        {
            return View();
        }

        /*-Enviar correo con el token de -*/
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RecuperarContrasena(string correo)
        {

            var buscar = _context.Usuarios.FirstOrDefault(lili => lili.Correo == correo);
            if (buscar == null) return RedirectToAction("RecuperarContrasena", new { error = true });

            buscar.TokenDRestauracion = Guid.NewGuid();
            buscar.CaducidadToken = DateTime.Now.AddMinutes(60);

            _context.Update(buscar);
            await _context.SaveChangesAsync();


            Utilerias.Correo.EnviarCorreo(buscar.Correo, "Restaurar contraseña", "El codigo de restauracion de contraseña es: \n" + buscar.TokenDRestauracion.ToString());

            return RedirectToAction("NuevaContrasena", new { Correo = buscar.Correo });
        }

        /*-Validar token de recuperacion-*/
        [AllowAnonymous]
        [HttpPost]
        public JsonResult ValidarTokenRestauracion(string token, string correo)
        {
            var buscar = _context.Usuarios.FirstOrDefault(lili => lili.Correo == correo && lili.TokenDRestauracion == Guid.Parse(token));

            if (buscar == null)
            {
                return new JsonResult(
                    new
                    {
                        resultado = false,
                        mensaje = "Token invalido"
                    });
            }
            if (DateTime.Now >= buscar.CaducidadToken)
            {
                return new JsonResult(
                    new
                    {
                        resultado = false,
                        mensaje = "El token ya ha caducado"
                    });
            }
            return new JsonResult(
                new
                {
                    resultado = true,
                    mensaje = "El token es válido y permite cambiar la contraseña"
                });
        }

        /*-Vista de cambiar contraseña-*/
        [AllowAnonymous]
        public IActionResult NuevaContrasena(string correo)
        {

            if (correo == null)
            {

                return RedirectToAction("Index", "Aplicacion");
            }
            ViewBag.Correo = correo;
            return View();
        }

        /*-JsonResult para restaurar la contraseña-*/
        [AllowAnonymous]
        [HttpPost]
        public JsonResult ContrasenaNueva(string correo, string token, string contrasena)
        {
            var buscar = _context.Usuarios.FirstOrDefault(lili => lili.Correo == correo && lili.TokenDRestauracion == Guid.Parse(token));
            if (buscar == null)
            {
                return new JsonResult(
                  new { resultado = false, mensaje = "El token no es válido" });
            }

            buscar.Contrasena = Utilerias.Encriptar.HashString(contrasena);
            _context.Update(buscar);
            _context.SaveChanges();

            return new JsonResult(
                new
                {
                    resultado = true,
                    mensaje = "la contraseña se actualizo correctamente"
                });
        }

        /*-JsonResult para Actualizar la contraseña-*/
        [AllowAnonymous]
        [HttpPost]
        public JsonResult ActualizarContrasena(string ContraActual, string NuevaContra1, string NuevaContra2)
        {

            if (NuevaContra1 != NuevaContra2)
                return new JsonResult(
                    new
                    {
                        resultado = false,
                        mensaje = "Las contraseñas nuevas no coinciden"
                    });

            var id = Guid.Parse(User.Claims.FirstOrDefault(lili => lili.Type == "Id").Value);
            var buscar = _context.Usuarios.FirstOrDefault(ana => ana.IdUsuario == id);

            if (buscar == null)
                return new JsonResult(
                    new
                    {
                        resultado = false,
                        mensaje = "Usuario no localizado"
                    });

            if (!Utilerias.Encriptar.VerifyHash(ContraActual, buscar.Contrasena))
                return new JsonResult(
                    new
                    {
                        resultado = false,
                        mensaje = "La contraseña actual es incorrecta"
                    });

            buscar.Contrasena = Utilerias.Encriptar.HashString(NuevaContra1);
            _context.Update(buscar);
            _context.SaveChanges();

            return new JsonResult(
                new
                {
                    resultado = true,
                    mensaje = "La contraseña se ha actualizado exitosamente"
                });

        }


        //**************************************************************************************************************************************************************************//
        //Apartado para todo lo referente al dashboard de la aplicación desde la vista del usuario normal (Cliente)
        [Authorize(Roles = "Usuario")]

        public IActionResult Dashboard()
        {
            return View();
        }


        //**************************************************************************************************************************************************************************//
        //Apartado para el dashboard y vistas del administrador desde la vista del administrador
        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            return View();
        }


        //**************************************************************************************************************************************************************************//
        //Apartado de acciones referentes a las vistas generales//

        /*-Apartado Para Vincular con la escuela-*/
        public IActionResult VincularEscuela()
        {
            return View();
        }

        /*-task-*/
        public async Task<IActionResult> VincularlaEscuela(string? codigo, [Bind ("IdUsuario,IdEscuela")] BdI_Usu_Esc bdI_Usu_Esc)
        {
            var ycqvm = _context.Escuela.FirstOrDefault(ltam => ltam.Codigo == codigo);
           
            if (ycqvm == null) return NotFound();

            if (ycqvm.Codigo != null)
            {
                bdI_Usu_Esc.IdEscuela = ycqvm.IdEscuela;
                var ppamhh = Guid.Parse(User.Claims.FirstOrDefault(lili => lili.Type == "Id").Value);
                bdI_Usu_Esc.IdUsuario = ppamhh;


                _context.Add(bdI_Usu_Esc);
                await _context.SaveChangesAsync();
                 return RedirectToAction("Index");
            }

            return View(bdI_Usu_Esc);
        }

    }
}
