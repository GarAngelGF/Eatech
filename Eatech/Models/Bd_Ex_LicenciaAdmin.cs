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
        [Key, DisplayName("Id Licencia")/*, MaxLength(11, ErrorMessage = "Cantidad de caracteres maxima (10) Alcanzada")*/]
        public Guid IdLicencia { get; set; }

        [Required, DisplayName ("Clave Licencia") , MinLength(10, ErrorMessage= "La licencia es de 10 digitos")]
        public string Clave { get; set; }

    }
}
