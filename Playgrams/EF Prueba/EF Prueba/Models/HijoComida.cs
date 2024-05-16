using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prueba
{
    internal class HijoComida
    {
        public int Id { get; set; }
        public int IdHijo { get; set; }
        public int IdComida { get; set; }
        public virtual Hijo Hijo { get; set; }
        public virtual Comida Comida { get; set; }

    }
}
