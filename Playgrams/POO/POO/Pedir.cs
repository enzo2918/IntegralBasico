using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Pedir:IPedir
    {
        private string cadena;
        private int entero;
        public int Entero() 
        {
            
            cadena = Console.ReadLine();
            entero = Convert.ToInt32(cadena);
            return entero;
        }
        public string Cadena()
        {
            cadena = Console.ReadLine();
            return cadena;
        }

    }
}
