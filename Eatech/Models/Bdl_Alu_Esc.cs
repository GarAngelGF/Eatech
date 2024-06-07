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

    [Keyless]
    public class Bdl_Alu_Esc
    {
        [Required, DisplayName("Id del Alumno")]
        public Guid IdAlumno { get; set; }

        [ForeignKey("IdAlumno")]
        public Bd_Usuario? Idalumno { get; set; }

        [Required, DisplayName("Id de la Escuela")]
        public Guid IdEscuela { get; set; }

        [ForeignKey("IdEscuela")]
        public Bd_Alumno? IdEsc { get; set; }

    }
}
