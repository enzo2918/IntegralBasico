using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prueba
{
    internal class Dni
    {
        public int Id { get; set; }
        public string NumeroDni { get; set; }
        //public int _IdHijo { get; set; }
        public Hijo Hijo { get; set; }

    }
}
