using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pruebAPI.Models;

namespace pruebAPI.Logica
{
    public class Validaciones
    {
        public static bool ValidarCliente(Cliente c)
        {
            bool flag = false;
            if (string.IsNullOrEmpty(c.Cedula))
            {
                flag = true;
            }
            if (string.IsNullOrEmpty(c.Nombre))
            {
                flag = true;
            }
            if (string.IsNullOrEmpty(c.Apellido))
            {
                flag = true;
            }
            if (string.IsNullOrEmpty(c.Telefono))
            {
                flag = true;
            }
            if (string.IsNullOrEmpty(c.Direccion))
            {
                flag = true;
            }
            if (string.IsNullOrEmpty(c.Correo))
            {
                flag = true;
            }
            return flag;
        }
    }
}
