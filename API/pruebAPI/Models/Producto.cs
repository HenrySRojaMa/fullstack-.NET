using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebAPI.Models
{
    public class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
}
