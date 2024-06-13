using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Security.Permissions;


namespace Eatech.Models
{
    public class Bd_Ingredientes
    {

        [Key, DisplayName("ID Ingrediente"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid IdIngrediente { get; set; }

        [Required, DisplayName("Ingrediente"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        [Remote("ValidarIngredientes", "Ingredientes", ErrorMessage = "Ingrediente ya registrado")]
        public string Nombre { get; set; }

        [Required,DisplayName("Tipo de ingrediente")]
        public string Tipo { get; set; }

    }
}
