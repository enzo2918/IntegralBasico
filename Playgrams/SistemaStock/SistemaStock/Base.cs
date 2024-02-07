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
        public List<Articulo> Articulo { get; set; } = new List<Articulo>();
    }
}
