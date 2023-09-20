using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CInicio inicio = new CInicio();
            inicio.Inicio();



            var numbers = new string[10]; 
            foreach (string numeros in numbers)
            {
                Console.Write("{0}" + " ", numeros);
            }
            
        }
    }
}
