using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using pruebaMVC.ClienteAPI;
using pruebaMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autenticar(Usuario u)
        {
            API api = new API();
            Sesion sesion = new Sesion();

            string usuario = Request.Form["usuario"];
            string pwd = Request.Form["pwd"];
            var rpta = api.Autenticar(new Usuario() { Codigo = usuario, Psw = pwd });
            if (rpta.Codigo == "000")
            {
                sesion.cliente = api.BuscarCliente(usuario);
                HttpContext.Session.SetString("DatosUsuario", JsonConvert.SerializeObject(sesion));
            }
            return Json(rpta);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
