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
        public string Nombre { get; set; }

        //Cambio en codigo, la variable "Cantidad" fue eliminada, por que no se le daria un uso "adecuado" Dentro del Programa 
        //// [Required, DisplayName(cantidad)]
        //// public int cantidad { get; set; }

        [Required,DisplayName("Tipo de ingrediente")]
        public string Tipo { get; set; }

    }
}
