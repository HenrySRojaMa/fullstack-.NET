using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pruebAPI.Logica;
using pruebAPI.Models;

namespace pruebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public List<Producto> ListarProductos()
        {
            return new SpProducto().ListarProductos();
        }
        [HttpPost]
        [Route("actualizar")]
        public Transaccion ActualizarProducto(Producto p)
        {
            return new SpProducto().ActualizarProducto(p);
        }
    }
}
