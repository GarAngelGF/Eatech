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

        [Required (ErrorMessage ="el correo es obligatorio"), EmailAddress(ErrorMessage = "Correo invalido"), DisplayName("Correo Electronico")]
        [MaxLength(50, ErrorMessage = "Cantidad de caracteres maxima (50) Alcanzada")]
        [Remote("ValidarCorreoUnico", "Aplicacion", ErrorMessage = "Correo ya registrado, Registrate con otro correo o inicia sesion")]
        public string Correo { get; set; }

        [Required (ErrorMessage ="la contraseña es obligatoria"), DisplayName("Contraseña"), DataType(DataType.Password)]
        [MinLength(10, ErrorMessage = "la contraseña tiene que tener minimo 10 caracteres")]
        public string? Contrasena { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DisplayName("Nombre") ]
        [MaxLength(50, ErrorMessage = "Cantidad de caracteres maxima (50) Alcanzada")]
        [MinLength(3, ErrorMessage = "El nombre debe tener mínimo 3 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [DisplayName("Apellido Paterno"), MaxLength(28, ErrorMessage = "Cantidad de caracteres maxima (28) Alcanzada")]
        [MinLength(2, ErrorMessage = "El Apellido debe tener mínimo 2 caracteres")]
        
        public string aPaterno { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [DisplayName("Apellido Materno"), MaxLength(28, ErrorMessage = "Cantidad de caracteres maxima (28) Alcanzada")]
        [MinLength(2, ErrorMessage = "El Apeliido debe tener mínimo 2 caracteres")]

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
