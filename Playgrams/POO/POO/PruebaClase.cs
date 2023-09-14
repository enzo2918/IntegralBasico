using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class PruebaClase
    {
        private int seleccion = 0;

        public void bienvenida()
        {
            Console.WriteLine("Bienvenido a la biblioteca");
            Console.WriteLine("Estas registrado? 1. Si  2. No");
            seleccion = pedirentero();

            if (seleccion != 1 && seleccion !=2)
            {
                Console.WriteLine("Por favor seleccion 1 si esta registrado o 2 en caso contrario")
            }
            if (seleccion = 1)
            {
                Console.WriteLine("Escribe tu nombre de usuario");
                dato 

            }

        }

    }
}
