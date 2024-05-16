using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class CalcularStockParams
    {
        public List<string> Origenes { get; set; }
        public Dictionary<string, List<Articulo>> ArticulosDelOrigen { get; set; }
        public Dictionary<(string,string), List<DT>> MovimientosDelArticulo { get; set; }

    }

    
}
