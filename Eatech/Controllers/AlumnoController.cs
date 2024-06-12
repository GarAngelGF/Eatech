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
        public IActionResult AñadirAlumno()
        {
            return View();
        }

        /*-Task para registrar al alumno en la base de datos. Tablas alumno e intermedia alum_usu-*/
        public async Task<IActionResult> RegistrarAlumno([Bind("IdAlumno,Nombre,aPaterno,aMaterno,Alergias,Enfermedades,PreferenciasComida,Notas")] Bd_Alumno bd_Alumno, [Bind("IdUsuario,IdAlumno")] BdI_Usu_Alum bdI_Usu_Alum)
        {
            if (ModelState.IsValid)
            {
                bd_Alumno.IdAlumno = Guid.NewGuid();
                var ID = User.FindFirst("Id")?.Value;
                Guid ltam;
                if (Guid.TryParse(ID, out ltam))
                {
                    bdI_Usu_Alum.IdUsuario = ltam;
                }
                bdI_Usu_Alum.IdAlumno = bd_Alumno.IdAlumno;
                _context.Add(bdI_Usu_Alum);
                _context.Add(bd_Alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(bd_Alumno);
        }


        //**************************************************************************************************************************************************************************//
        //Apartado con todo lo relacionado al alumno dashboard (es la parte del view)

        //Nota: implementar cambios a la bd pa mañana
        public IActionResult AlumnoDashboard(Guid? id)
        {
            if (id == null || _context.Alumnos == null) return NotFound();
            var LContexto = _context.Intermedia_Usuario_Alumno.Include(li => li.alumno).Include(gzl => gzl.usuario).Where(cerv => cerv.IdUsuario == id);
            if (LContexto == null) return NotFound();
            return View(LContexto);
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
            if (id == null || _context.Alumnos == null) return NotFound();
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
            var Contexto = _context.Intermedia_Usuario_Alumno.Include(li => li.alumno).Include(gzl => gzl.usuario);
            return View(Contexto);
        }

    }
}
