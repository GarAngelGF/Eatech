using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Permissions;


namespace Eatech.Models
{

    [Keyless]
    public class BdI_Usu_Alum
    {
        
        [Required, DisplayName("Id del Usuario")]
        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Bd_Usuario? IdUsu { get; set; }

        [Required, DisplayName("Id del Alumno")]

        public Guid IdAlumno { get; set; }

        [ForeignKey("IdAlumno")]

        public Bd_Alumno? Idalumno { get; set; }

        //Relaciones con las demas tablas
        public ICollection<Bd_Alumno>? alumno {  get; set; }
        public ICollection<Bd_Usuario>? usuario {  get; set; }

    }



}



