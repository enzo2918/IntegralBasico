using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class StockArticulo
    {
        public int Stock { get; set; }
        public Articulo Articulo { get; set; }
        public string Origen { get; set; }
    }
}
