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
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [Route("loggin")]
        public Transaccion Autenticar(Usuario u)
        {
            return new SpCliente().Autenticar(u);
        }
        [HttpPost]
        [Route("ingresar")]
        public Transaccion IngresarCliente(Cliente c)
        {
            return new SpCliente().IngresarCliente(c);
        }
        [HttpPost]
        [Route("actualizar")]
        public Transaccion ActualizarCliente(Cliente c)
        {
            return new SpCliente().ActualizarCliente(c);
        }
        [HttpGet]
        [Route("buscar")]
        public Cliente BuscarCliente(string Id)
        {
            return new SpCliente().BuscarCliente(Id);
        }
    }
}
