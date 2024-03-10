using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class Tienda
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<int> IdBases { get; set; } = new List<int>();
        public List<string> IdEtiquetas { get; set; } = new List<string>();
    }
}
