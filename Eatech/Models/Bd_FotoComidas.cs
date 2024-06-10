using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Security.Permissions;


namespace Eatech.Models
{
    public class Bd_FotoComidas
    {

        [Key, DisplayName("ID FotoComida")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FotoComidaID { get; set; }

        [DisplayName("Comida")]
        [Required(ErrorMessage = "El ID del evento es obligatorio")]
        public Guid IDComida { get; set; }

        [DisplayName("Imagen")]
        [Required(ErrorMessage = "La imagen es obligatoria")]
        public string? Imagen { get; set; }

        /* Sección donde se indican las llaves foráneas */
        [ForeignKey("IDComida")]
        public Bd_Comida? bd_comida { get; set; }

    }
}
