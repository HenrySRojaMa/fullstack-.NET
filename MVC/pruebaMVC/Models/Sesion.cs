using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaMVC.Models
{
    public class Sesion
    {
        public int[] cantidades { get; set; }
        public Cliente cliente { get; set; }
        public List<Detalle> detalles { get; set; }
        public double Total { get; set; }
    }
}
