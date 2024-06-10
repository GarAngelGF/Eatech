using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Security.Permissions;

namespace Eatech.Models
{
    public class Bd_FotoAlumno
    {

        [Key, DisplayName("ID Alumno Foto"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IDAlumno { get; set; }

        [DisplayName("Alumno")]
        [Required(ErrorMessage = "El ID del evento es obligatorio")]
        public Guid IDAlumnoo { get; set; }

        [DisplayName("Imagen")]
        [Required(ErrorMessage = "La imagen es obligatoria")]
        public string? Imagen { get; set; }

        /* Sección donde se indican las llaves foráneas */
        [ForeignKey("IDAlumno")]
        public Bd_Alumno? bd_alumno { get; set; }

    }
}
