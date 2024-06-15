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
    public class BdI_Alu_Ped
    {
        [Key, DisplayName("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required, DisplayName("Id del pedido")]
        public Guid pedido { get; set; }

        [ForeignKey("pedido")]
        public Bd_Pedido? Pedido { get; set; }


        //Relaciones con las demas tablas
        [Required, DisplayName("Id del alumno")]
        public Guid IdAlumno { get; set; }

        [ForeignKey("IdAlumno")]
        public Bd_Alumno? Idalumno { get; set; }


        public ICollection<Bd_Pedido>? pedidos { get; set; }
        public ICollection<Bd_Alumno>? alumnos { get; set; }
    }
}
