﻿using System;
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
    [Authorize]
    //Nota: La mayoria de este controller va a ser accesible para los admin :o
    public class ComidaController : Controller
    {
        //**************************************************************************************************************************************************************************//
        //contextos base de datos
        private readonly ContextoBD _context;
        public ComidaController(ContextoBD context)
        {
            _context = context;
        }
        //**************************************************************************************************************************************************************************//
        /*-Index con el menu de la comida disponible-*/
        public async Task<IActionResult> Index()
        {
            var lid = Guid.Parse(User.Claims.FirstOrDefault(lili => lili.Type == "Id").Value);

            var LContexto = _context.Intermedia_Usuario_Alumno.Include(li => li.alumno).Include(gzl => gzl.usuario).Where(cerv => cerv.IdUsuario == lid);
            return View(await LContexto.ToListAsync());
        }

        //Crud papayadecelayafifirisfraissopadepapasuperpaposaespiromastoreiclo
        //**************************************************************************************************************************************************************************//
        /*-Apartado para todo sobre el crear comida-*/


        //**************************************************************************************************************************************************************************//
        /*-Apartado para detalles de la comida-*/


        //**************************************************************************************************************************************************************************//
        /*-Apartado para Editar la comida-*/


        //**************************************************************************************************************************************************************************//
        /*-Apartado para eliminar la comida-*/


        //**************************************************************************************************************************************************************************//
        /*-Admin Dashboard-*/
        //**************************************************************************************************************************************************************************//
        /*--*/

    }
}
