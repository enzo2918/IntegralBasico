using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class Factura
    {
        public List<Detalle> Detalles { get; set; } = new List<Detalle>();

        public int IdBase { get; set; }
        public int Id { get; set; }

        public TipoFactura TipoFactura { get; set; }

    }
}
