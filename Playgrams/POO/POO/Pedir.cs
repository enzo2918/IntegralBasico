using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CPedir
    {
        private string dato = "";
        private int seleccion = 0;
        public int pedirentero() 
        {
            
            dato = Console.ReadLine();
            seleccion = Convert.ToInt32(dato);
            return seleccion;
        }
        public string pedircadena()
        {
            dato = Console.ReadLine();
            return dato;
        }

    }
}
