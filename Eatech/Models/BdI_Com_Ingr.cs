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
    public class BdI_Com_Ingr
    {
        [Required, DisplayName("Id de la comida")]
        public Guid IDComida { get; set; }
        [ForeignKey("IDComida")]
        public Bd_Comida? IDcomida { get; set; }

        [Required, DisplayName("Id del Ingrediente")]
        public Guid IdIngrediente { get; set; }
        [ForeignKey("IdIngrediente")]
        public Bd_Ingredientes? Idingrediente { get; set; }

        public ICollection<Bd_Comida>? Comida { get; set;}
        public ICollection<Bd_Ingredientes>? Ingredientes {  get; set; } 

    }
}
