using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prueba
{
    internal class Comida
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<HijoComida> HijosComidas { get; set; }

    }
}
