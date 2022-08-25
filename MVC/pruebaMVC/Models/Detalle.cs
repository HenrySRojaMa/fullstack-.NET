using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaMVC.Models
{
    public class Detalle
    {
        public Producto producto { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
    }
}
