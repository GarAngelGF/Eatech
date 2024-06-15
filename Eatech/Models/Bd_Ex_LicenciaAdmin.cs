using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Security.Permissions;

namespace Eatech.Models
{
    public class Bd_Ex_LicenciaAdmin
    {
        [Key, DisplayName("Id Licencia")]
        public Guid IdLicencia { get; set; }

        [DisplayName ("Clave del programa")]
        public string ClaveLicencia { get; set; }
        [DisplayName("Usuario")]
        public Guid? IdUsuario { get; set; }

        [ForeignKey("ClaveLicencia")]
        public Bd_Ex_ClaveLicenciaVerifi ClaveNavigation { get; set; }
        [ForeignKey("IdUsuario")]
        public Bd_Usuario Usuario { get; set; }
    }
}
