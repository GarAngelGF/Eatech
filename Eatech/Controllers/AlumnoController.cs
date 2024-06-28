using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eatech.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Runtime.ConstrainedExecution;

namespace Eatech.Controllers
{
    [Authorize]
    public class AlumnoController : Controller
    {
        //**************************************************************************************************************************************************************************//
        //contextos base de datos
        private readonly ContextoBD _context;


        public AlumnoController(ContextoBD context)
        {
            _context = context;

        }


        //**************************************************************************************************************************************************************************//

        public async Task<IActionResult> Index()
        {
            var lid = Guid.Parse(User.Claims.FirstOrDefault(lili => lili.Type == "Id").Value);

            var LContexto = _context.Intermedia_Usuario_Alumno.Include(li => li.alumno).Include(gzl => gzl.usuario).Where(cerv => cerv.IdUsuario == lid);
            return View(await LContexto.ToListAsync());
        }


        //**************************************************************************************************************************************************************************//
        /*-Seccion referente a añadir a un alumno por parte del usuario mediante una vista-*/

        [Authorize(Roles = "Usuario")]
        public IActionResult AñadirAlumno()
        {
            return View();
        }

        /*-Task para registrar al alumno en la base de datos. Tablas alumno e intermedia alum_usu-*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarAlumno([Bind("IdAlumno,NoMatricula,Nombre, aPaterno,aMaterno,Alergias,Enfermedades,GradoEscolar,Notas")] Bd_Alumno bd_Alumno)
        {
            if (ModelState.IsValid)
            {
                BdI_Usu_Alum bdI_Usu_Alum = new BdI_Usu_Alum();
                bd_Alumno.IdAlumno = Guid.NewGuid();
                _context.Add(bd_Alumno);
                await _context.SaveChangesAsync();
                var ID = User.FindFirst("Id")?.Value;
                Guid ltam;
                if (Guid.TryParse(ID, out ltam))
                {
                    bdI_Usu_Alum.IdUsuario = ltam;
                }
                bdI_Usu_Alum.IdAlumno = bd_Alumno.IdAlumno;
                bdI_Usu_Alum.Id = bd_Alumno.IdAlumno;
                _context.Add(bdI_Usu_Alum);
                await _context.SaveChangesAsync();
                return RedirectToAction("AñadirAlumno", "Alumno");

            }

            return View(bd_Alumno);
        }

        /*-Validar si la matricula del alumno ya fue registrada-*/
        [AllowAnonymous]
        public IActionResult ValidarMatricula(string Matricula)
        {
            var busqueda = _context.Alumnos.FirstOrDefault(Li => Li.NoMatricula == Matricula);
            if (busqueda == null) return Ok(true);
            return Ok(false);
        }


        //**************************************************************************************************************************************************************************//
        //Apartado con todo lo relacionado al alumno dashboard (es la parte del view)

        //Nota: implementar cambios a la bd pa mañana

        //[Authorize(Roles="Usuario")]
        //public IActionResult AlumnoDashboard()
        //{
        //    var id = Guid.Parse(User.Claims.FirstOrDefault(lili => lili.Type == "Id").Value);
        //    if (id == null || _context.Alumnos == null) return NotFound();
        //    var LContexto = _context.Intermedia_Usuario_Alumno.Include(li => li.alumno).Include(gzl => gzl.usuario).Where(cerv => cerv.IdUsuario == id);
        //    if (LContexto == null) return NotFound();
        //    return View();
        //}

        [Authorize(Roles = "Usuario")]

        public async Task<IActionResult> AlumnoDashboard()
        {
            var idClaim = User.Claims.FirstOrDefault(lili => lili.Type == "Id");
            if (idClaim == null) return NotFound("Usuario no encontrado.");

            Guid id;
            if (!Guid.TryParse(idClaim.Value, out id)) return NotFound("Id de usuario no válido.");

            var alumnos = await _context.Alumnos.Where(a => _context.Intermedia_Usuario_Alumno.Any(i => i.IdUsuario == id && i.IdAlumno == a.IdAlumno)).ToListAsync();
            return View(alumnos);
        }


        //**************************************************************************************************************************************************************************//
        //Apartado de editar los valores del alumno
        public async Task<IActionResult> EditarAlumno(Guid? Id)
        {
            if (Id == null || _context.Alumnos == null) return NotFound();
            var alumno = await _context.Alumnos.FindAsync(Id);
            if (alumno == null) return NotFound();
            return View(alumno);
        }

        /*-Seccion para editar al alumno en la base de datos-*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarAlumno(Guid Id, [Bind("Nombre,aPaterno,aMaterno,Alergias,Enfermedades,PreferenciasComida,GradoEscolar,Notas")] Bd_Alumno bd_alumno)
        {
            if (Id != bd_alumno.IdAlumno) return NotFound();
            try
            {
                _context.Update(bd_alumno);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoEx(bd_alumno.IdAlumno)) return NotFound();
                else throw;
            }
            return View(bd_alumno);
        }

        /*-Comprueba si el guid de alumno id existe-*/
        private bool AlumnoEx(Guid id)
        {
            return (_context.Alumnos?.Any(lili => lili.IdAlumno == id)).GetValueOrDefault();
        }

        //**************************************************************************************************************************************************************************//
        //Apartado para dar de baja a un alumno
        public async Task<IActionResult> BajaAlumno(Guid? id)
        {
            id = Guid.Parse(User.FindFirstValue("Id"));
            if (id == null) return NotFound();
            var LContexto = _context.Intermedia_Usuario_Alumno.Include(li => li.alumno).Include(gzl => gzl.usuario).Where(cerv => cerv.IdUsuario == id);
            if (LContexto == null) return NotFound();
            return View(LContexto);
        }

        /*-task para borrar al alumno desde la base de datos*/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarBaja(Guid id)
        {
            if (id == null || _context.Alumnos == null) return Problem("Alumno no encontrado");
            var Ltam = await _context.Alumnos.FindAsync(id);
            var lili = await _context.Intermedia_Alum_Pedi.FindAsync(id);
            var gnlz = await _context.Intermedia_Usuario_Alumno.FindAsync(id);

            if (Ltam != null && lili != null && gnlz != null)
            {
                _context.Intermedia_Alum_Pedi.Remove(lili);
                _context.Intermedia_Usuario_Alumno.Remove(gnlz);
                _context.Alumnos.Remove(Ltam);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        //**************************************************************************************************************************************************************************//
        /*-Apartado de vistas de administrador-*/
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminDashboardAlumnos()
        {
           
            var alumnos = await _context.Alumnos.ToListAsync();
            return View(alumnos);
        }


        [Authorize(Roles = "Usuario")]
        public IActionResult AlumnoBuscar()
        {

            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult AdminAlumnoBuscar()
        {






            return View();
        }

        public async Task<IActionResult> BuscarAlumnoCT(string AlumnoMatricula)
        {
            var userId = User.Identity.Name;
           
           

            //aqui alumno1 ya agarra bien el valor el alumno buscado :D
            var alumno1 = _context.Alumnos.FirstOrDefault(b => b.NoMatricula == AlumnoMatricula);

            if (alumno1 == null)
            {
                //    return NotFound("Alumno no encontrado.");
                return Json(new { success = false, message = "Alumno no encontrado." });
            }


            //hasta aqui todo jala bien

            var pedidoIds = _context.Intermedia_Alum_Pedi.Where(pi => pi.IdAlumno == alumno1.IdAlumno).Select(pi => pi.pedido).ToList();



            if (pedidoIds.Count == 0)
            {
                //return NotFound("Pedidos no encontrados para el alumno " + alumno1.Nombre);
                return Json(new { success = false, message = $"Pedidos no encontrados para el alumno {alumno1.Nombre}." });

            }


            var pedidosf = _context.Pedidos.Where(p => pedidoIds.Contains(p.pedido)).Select(p => new
            {
                alumnoNombre = alumno1.Nombre,
                alumnoapaterno = alumno1.aPaterno,
                alumnoamaterno = alumno1.aMaterno,
                fechaPedido = p.FechaCPedido,
                fechaEntregaa = p.FechaEntrega,
                estatusPedido = p.Estatus,
                alumnogrado = alumno1.GradoEscolar,
                alumnopadecimiento = alumno1.Enfermedades,
                alumnoaler = alumno1.Alergias,
                alumnonotas = alumno1.Notas,

                //nombrecomida = _context.Comidas.Where(a => a.IDComida == .FirstOrDefault()).Select(a => a.Nombre).FirstOrDefault(),
                


            }).ToList();

            if (pedidosf == null)
            {
                return NotFound("No se encontraron pedidos.");
            }


            //ViewBag.Pedidos = pedidosf;

            //return View("Buscar", pedidosf);

            return Json(new { success = true, pedidos = pedidosf });
        }


    }
}
