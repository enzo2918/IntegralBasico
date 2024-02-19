using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Factura> Facturas { get; set; } = new List<Factura>();
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
