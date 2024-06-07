using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eatech.Models;
using Eatech.Utilerias;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.Design;
using NuGet.Protocol.Plugins;
using System.Security.Cryptography;


namespace Eatech.Controllers
{
    //controller pa admin y usuario
    [Authorize]
    public class PedidoController : Controller
    {
        //**************************************************************************************************************************************************************************//
        //contextos base de datos
        private readonly ContextoBD _context;
        public PedidoController(ContextoBD context)
        {
            _context = context;
        }
        //**************************************************************************************************************************************************************************//
        /*-Index donde se muestran el historial de pedidos-*/
        public IActionResult Index()
        {
            return View();
        }
        //**************************************************************************************************************************************************************************//
        /*-Apartado para crear el pedido + envio de correo por parte del cliente y admin-*/


        //**************************************************************************************************************************************************************************//
        /*-Apartado para editar el estatus del pedido por parte del admin + envio de correo al cliente para -*/


        //**************************************************************************************************************************************************************************//
        /*-Apartado para eliminar pedidos mayores a 1 año para ahorrar almacenamiento en la base de datos [Solo admin]-*/


        //**************************************************************************************************************************************************************************//
        /*-Apartado para ver el pedido de manera individual-*/


        //**************************************************************************************************************************************************************************//
        /*-apartado vistas de admin [dashboard, etc]-*/
    }
}
