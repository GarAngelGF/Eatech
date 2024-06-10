using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Security.Permissions;


namespace Eatech.Models
{
    public class Bd_Pedido
    {
        [Key, DisplayName("No de Pedido"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid pedido { get; set; }

        //Esta fecha es del momento en donde el usuario crea el pedido
        [Required, DataType(DataType.DateTime, ErrorMessage = "Formato de fecha incorrecto"), DisplayName("Fecha de creacion")]
        public DateTime FechaCPedido { get; set; }

        //--Parametro añadido: FechaEntregaComida
        //Esta fecha es de cuando se le va a dar de comer al "Alumno"
        [Required, DataType(DataType.DateTime, ErrorMessage = "Formato de fecha incorrecto"), DisplayName("Fecha de entrega")]
        public DateTime FechaEntrega { get; set; }


        /*- AGREGAR TIPO ESTATUS DEL PEDIDO-*/

        //Cambio: Pasamos la variable "Nota" de la clase "comida" a la clase "Pedido"
        [DisplayName("Notas Pedido")]
        public string NotaPedido { get; set; }


        [Required,DisplayName("Estatus del pedido")]
        public string Estatus { get; set; }  
    }
}
