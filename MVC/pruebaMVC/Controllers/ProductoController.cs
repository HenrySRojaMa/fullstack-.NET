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
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            Sesion sesion = JsonConvert.DeserializeObject<Sesion>(HttpContext.Session.GetString("DatosUsuario"));
            sesion.detalles = new List<Detalle>();
            sesion.Total = 0;
            HttpContext.Session.SetString("DatosUsuario", JsonConvert.SerializeObject(sesion));
            ViewBag.productos=new API().ListarProductos();
            return View("~/Views/Producto/Producto.cshtml");
        }
        public IActionResult ModalPago()
        {
            Sesion sesion = JsonConvert.DeserializeObject<Sesion>(HttpContext.Session.GetString("DatosUsuario"));
            ViewBag.detalles = sesion.detalles;
            ViewBag.cliente = sesion.cliente;
            ViewBag.total = sesion.Total;
            return PartialView("~/Views/Shared/ModalPago.cshtml");
        }
        [HttpPost]
        public void AgregarProducto(int[]_cantidades, List<Producto>_productos)
        {
            Sesion sesion = JsonConvert.DeserializeObject<Sesion>(HttpContext.Session.GetString("DatosUsuario"));
            for (int i = 0; i < _cantidades.Length; i++)
            {
                if (_cantidades[i]!=0)
                {
                    sesion.detalles.Add(new Detalle()
                    {
                        Cantidad = _cantidades[i],
                        producto = _productos[i],
                        Total = _cantidades[i] * _productos[i].Precio
                    });
                }
            }
            foreach (var item in sesion.detalles)
            {
                sesion.Total +=item.Total;
            }
            HttpContext.Session.SetString("DatosUsuario", JsonConvert.SerializeObject(sesion));
        }
        public int ActualizarProductos()
        {
            Sesion sesion = JsonConvert.DeserializeObject<Sesion>(HttpContext.Session.GetString("DatosUsuario"));
            foreach (var item in sesion.detalles)
            {
                new API().ActualizarProducto(new Producto() {
                    Codigo=item.producto.Codigo,
                    Descripcion = item.producto.Descripcion,
                    Nombre = item.producto.Nombre,
                    Precio = item.producto.Precio,
                    Stock = item.producto.Stock-item.Cantidad
                });
            }
            return 0;
        }
    }
}
