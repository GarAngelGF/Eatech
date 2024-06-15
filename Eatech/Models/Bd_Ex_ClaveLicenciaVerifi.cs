using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Security.Permissions;

namespace Eatech.Models
{
    public class Bd_Ex_ClaveLicenciaVerifi
    {
        [Key,DisplayName("Clave dada de alta")]
        [MinLength(10)]
        public string Clave { get; set; }
    }
}
