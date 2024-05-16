using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prueba
{
    internal class Cumpleaños
    {
        public int Id { get; set; }
        public DateTime FechaCumpleaños { get; set; }
        public ICollection<Hijo> Hijos { get; set; }
    }
}
