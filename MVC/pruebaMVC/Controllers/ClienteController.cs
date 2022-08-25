using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pruebaMVC.ClienteAPI;
using pruebaMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaMVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            Sesion sesion = JsonConvert.DeserializeObject<Sesion>(HttpContext.Session.GetString("DatosUsuario"));
            ViewBag.usuario=sesion.cliente;
            return View("~/Views/Cliente/Cliente.cshtml");
        }
        [HttpPost]
        public IActionResult IngresarCliente()
        {
            Cliente c = new Cliente() {
                Cedula= Request.Form["Identificacion"],
                Nombre = Request.Form["Nombre"],
                Apellido = Request.Form["Apellido"],
                Telefono = Request.Form["Telefono"],
                Direccion = Request.Form["Direccion"],
                Direccion2 = Request.Form["Direccion2"],
                Correo = Request.Form["Correo"]
            };
            return Json(new API().IngresarCliente(c));
        }
        [HttpPost]
        public IActionResult ActualizarCliente()
        {
            Cliente c = new Cliente()
            {
                Cedula = Request.Form["Identificacion"],
                Nombre = Request.Form["Nombre"],
                Apellido = Request.Form["Apellido"],
                Telefono = Request.Form["Telefono"],
                Direccion = Request.Form["Direccion"],
                Direccion2 = Request.Form["Direccion2"],
                Correo = Request.Form["Correo"]
            };
            return Json(new API().ActualizarCliente(c));
        }
    }
}
