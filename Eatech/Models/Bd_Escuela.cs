using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Security.Permissions;


namespace Eatech.Models
{
    public class Bd_Escuela
    {
        [Key, DisplayName("Id Escuela"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdEscuela { get; set; }

        [Required, MaxLength(10, ErrorMessage ="El codigo de la escuela debe de ser de 10 caracteres")]
        [Remote ("ValidarCodigoEscuela", "Escuela" , ErrorMessage ="La escuela ya fue registrada")]
        public string ClaveEscuela {  set; get; }

        [Required, DisplayName("Escuela"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        public string Nombre { get; set; }

        [Required, DisplayName("Codigo"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        public string Codigo { get; set; }


    }
}
