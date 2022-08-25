using Newtonsoft.Json;
using pruebaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace pruebaMVC.ClienteAPI
{
    public class API
    {
        string urlBase = Environment.GetEnvironmentVariable("urlAPI").ToString();

        public Transaccion Autenticar(Usuario u)
        {
            Transaccion rpta = new Transaccion();
            try
            {
                string urlServicio = urlBase + "cliente/loggin";
                HttpClient clienteHttpExterno = new HttpClient();
                HttpResponseMessage response = clienteHttpExterno.PostAsync(urlServicio, new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    rpta = JsonConvert.DeserializeObject<Transaccion>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    rpta.Codigo = "001";
                    rpta.Mensaje = "Error de conexion" + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                rpta.Codigo = "001";
                rpta.Mensaje = "Error: " + ex.Message;
            }
            return rpta;
        }
        public Transaccion IngresarCliente(Cliente c)
        {
            Transaccion rpta = new Transaccion();
            try
            {
                string urlServicio = urlBase + "cliente/ingresar";
                HttpClient clienteHttpExterno = new HttpClient();
                HttpResponseMessage response = clienteHttpExterno.PostAsync(urlServicio, new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    rpta = JsonConvert.DeserializeObject<Transaccion>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    rpta.Codigo = "001";
                    rpta.Mensaje = "Error de conexion" + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                rpta.Codigo = "001";
                rpta.Mensaje = "Error: " + ex.Message;
            }
            return rpta;
        }
        public Transaccion ActualizarCliente(Cliente c)
        {
            Transaccion rpta = new Transaccion();
            try
            {
                string urlServicio = urlBase + "cliente/actualizar";
                HttpClient clienteHttpExterno = new HttpClient();
                HttpResponseMessage response = clienteHttpExterno.PostAsync(urlServicio, new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    rpta = JsonConvert.DeserializeObject<Transaccion>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    rpta.Codigo = "001";
                    rpta.Mensaje = "Error de conexion" + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                rpta.Codigo = "001";
                rpta.Mensaje = "Error: " + ex.Message;
            }
            return rpta;
        }
        public Cliente BuscarCliente(string Id)
        {
            Cliente cliente = new Cliente();
            try
            {
                string urlServicio = urlBase + "cliente/buscar?id=" + Id;
                HttpClient clienteHttpExterno = new HttpClient();
                HttpResponseMessage response = clienteHttpExterno.GetAsync(urlServicio).Result;
                if (response.IsSuccessStatusCode)
                {
                    cliente = JsonConvert.DeserializeObject<Cliente>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    cliente = null;
                }
            }
            catch (Exception)
            {

                cliente = null;
            }
            return cliente;
        }

        public List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                string urlServicio = urlBase + "producto/listar";
                HttpClient clienteHttpExterno = new HttpClient();
                HttpResponseMessage response = clienteHttpExterno.GetAsync(urlServicio).Result;
                if (response.IsSuccessStatusCode)
                {
                    productos = JsonConvert.DeserializeObject<List<Producto>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    productos = null;
                }
            }
            catch (Exception)
            {

                productos = null;
            }
            return productos;
        }
        public Transaccion ActualizarProducto(Producto p)
        {
            Transaccion rpta = new Transaccion();
            try
            {
                string urlServicio = urlBase + "producto/actualizar";
                HttpClient clienteHttpExterno = new HttpClient();
                HttpResponseMessage response = clienteHttpExterno.PostAsync(urlServicio, new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    rpta = JsonConvert.DeserializeObject<Transaccion>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    rpta.Codigo = "001";
                    rpta.Mensaje = "Error de conexion" + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                rpta.Codigo = "001";
                rpta.Mensaje = "Error: " + ex.Message;
            }
            return rpta;
        }

    }
}
