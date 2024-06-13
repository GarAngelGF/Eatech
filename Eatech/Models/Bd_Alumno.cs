using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Security.Permissions;

namespace Eatech.Models
{
    public class Bd_Alumno
    {
        [Key, DisplayName("Matricula Alumno"), MaxLength(11, ErrorMessage = "Cantidad de caracteres maxima (10) Alcanzada")]
        public Guid IdAlumno { get; set; }

        [Required, DisplayName("No.Matricula"),MinLength(10, ErrorMessage ="La matricula debe de ser de 10 caracteres")]
        [Remote("ValidarMatricula", "Alumno", ErrorMessage = "Alumno ya registrado, Contacte con soporte tecnico si usted no ha registrado al alumno")]
        public string NoMatricula { get; set; }

        [Required, DisplayName("Nombre"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        public string Nombre { get; set; }

        [Required, DisplayName("Apellido Paterno"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        public string aPaterno { get; set; }

        [Required, DisplayName("Apellido Materno"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        public string aMaterno { get; set; }

        //datos medicos de los estudiantes
        //no usan el "Required por que no todos los estudiantes tienen una/s alergias y/o enfermedades
        [DisplayName("Alergias"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        public string Alergias { get; set; }

        [DisplayName("Enfermedades"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        public string Enfermedades { get; set; }

        //Preferencias alimentarias de los alumnos, tampoco van con "Required", ya que estos campos son opcionales
        [DisplayName("Preferencias de alimentos"), MaxLength(528, ErrorMessage = "Cantidad de caracteres maxima (528) Alcanzada")]
        public string PreferenciasComida { get; set; }

        //Datos 
        [Required, DisplayName("Grado escolar")]
        public string GradoEscolar { get; set; }

        //Notas para que los alumnos puedan crear 
        //cambio de nombre "observaciones" --> "notas"
        [DisplayName("Notas"), MaxLength(528, ErrorMessage = "Cantidad de caracteres maxima (528) Alcanzada")]
        public string Notas { get; set; }

        public ICollection<Bd_FotoAlumno> Foto {  get; set; }   
    }

}
