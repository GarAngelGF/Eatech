using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Security.Permissions;


namespace Eatech.Models
{
    public class Bd_Comida
    {
        // id comida *Momentaneamente le ponemos identity (Definir si se queda o no)
        [Key, DisplayName("ID Comida"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IDComida { get; set; }

        [Required, DisplayName("Comida"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        public string Nombre { get; set; }

        [Required, DisplayName("Estado visibilidad")]
        public string Visibilidad { get; set; }

        [Required, DisplayName("Porciones totales")]
        public int Porciones { get; set; }

        //Accion a porciones disp.= Se validaran con el controlador mediante la linea de codigo "Remote"
        [Required, DisplayName("Porciones restantes")]
        [Remote("ValidarPorcionesDisponibles", "Aplicacion", ErrorMessage = "Ya no hay porciones disponibles")]
        public int PorcionesDisponibles { get; set; }

        public ICollection<Bd_FotoComidas> FotosComidas { get; set; }

    }
}
