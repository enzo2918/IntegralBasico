using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Pedir:IPedir
    {
        private string dato = "";
        private int seleccion = 0;
        public int PedirEntero() 
        {
            
            dato = Console.ReadLine();
            seleccion = Convert.ToInt32(dato);
            return seleccion;
        }
        public string PedirCadena()
        {
            dato = Console.ReadLine();
            return dato;
        }

    }
}
