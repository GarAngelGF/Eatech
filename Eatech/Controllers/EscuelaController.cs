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
    //Apartado en su mayoria para admin
    [Authorize]
    public class EscuelaController : Controller
    {
        //**************************************************************************************************************************************************************************//
        //contextos base de datos
        private readonly ContextoBD _context;
        public EscuelaController(ContextoBD context)
        {
            _context = context;
        }


        //**************************************************************************************************************************************************************************//
        /*-apartado para visualizar los datos de la escuela -*/
        public IActionResult Index()
        {
            return View();
        }
        //**************************************************************************************************************************************************************************//
        /*-Apartado para registrar la escuela + generar un guid de invitacion para vincular al usuario con la esta cosa-*/


        //**************************************************************************************************************************************************************************//
        /*-Apartado para ver la lista de la usuarios vinculados a la escuelonchaponcha-*/


        //**************************************************************************************************************************************************************************//
        /*-Apartado para eliminar usuarios/Escuela de la bd-*/


        //**************************************************************************************************************************************************************************//
        /*-Apartado para editar las cosas de la escuela menos el codigo de invitacion-*/


        //**************************************************************************************************************************************************************************//
        /*-admin vistas plus-*/
    }
}
