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
    public class BdI_Usu_Esc
    {

        [Required, DisplayName("Id del Usuario")]
        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Bd_Usuario Idusuario { get; set; }


        [Required, DisplayName("Id de la Escuela")]

        public Guid IdEscuela { get; set; }

        [ForeignKey("IdEscuela")]

        public Bd_Escuela Idescuela { get; set; }

        /*-conecciones a tablas fuertes-*/
        public ICollection<Bd_Usuario>? Usuario{get; set;}
        public ICollection<Bd_Escuela>? Escuela{get; set;}

    }
}


