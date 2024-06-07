using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Security.Permissions;

namespace Eatech.Models
{
    public class Bd_Usuario
    {
        [Key, DisplayName("Id Usuario")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdUsuario { get; set; }

        [Required, EmailAddress(ErrorMessage = "Correo invalido"), DisplayName("Correo Electronico")]
        [Remote("ValidarCorreoUnico", "Aplicacion", ErrorMessage = "Correo ya registrado, Registrate con otro correo o inicia sesion")]
        public string Correo { get; set; }

        [Required, DisplayName("Contraseña"), DataType(DataType.Password)]
        public string? Contrasena { get; set; }

        [Required, DisplayName("Nombre"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        public string Nombre { get; set; }

        [DisplayName("Apellido Paterno"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        public string aPaterno { get; set; }

        [DisplayName("Apellido Materno"), MaxLength(128, ErrorMessage = "Cantidad de caracteres maxima (128) Alcanzada")]
        public string aMaterno { get; set; }



        //datos de creacion 

        [Required, DataType(DataType.DateTime, ErrorMessage = "Formato incorrecto"), DisplayName("Fecha de creacion de la cuenta")]
        public DateTime FechaCreacion { get; set; }

        [DisplayName("Token de restauracion")]
        public Guid? TokenDRestauracion { get; set; }

        [DisplayName("Caducidad del token"), DataType(DataType.DateTime, ErrorMessage = "Formato incorrecto")]
        public DateTime CaducidadToken { get; set; }

        [DisplayName("Rol")]
        public string? Rol { get; set; }

    }
}
