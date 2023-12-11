using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int>();
            numeros.AddRange(new int[] { 0,1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Predicate<int> delegado = new Predicate<int>(pares);

            List<int> numerosOrdenados = numeros.FindAll(delegado);
            var pares2 = numeros.Any(pares);

            IEnumerable<int> numerospares = numeros.Where(x =>
            {
                if (x == 0)
                {
                    Console.WriteLine("es cero");
                    return true;
                }
                if (x == 1)
                {
                    Console.WriteLine("es uno");
                    return true;
                }
                if (x == 2)
                {
                    Console.WriteLine("es dos");
                    return true;
                }
                if (x == 3)
                {
                    Console.WriteLine("es tres");
                    return true;
                }
                if (x == 4)
                {
                    Console.WriteLine("es cuatro");
                    return true;
                }
                else
                {
                    Console.WriteLine("no es ninguno de los anteriores");
                    return false;
                }    
            });


            dynamic num = "";
            var pepe = num + 2;

            foreach (int i in numerospares) { Console.WriteLine(i); }

            foreach (int i in numerosOrdenados) { Console.WriteLine(i); }
        }
        static bool pares(int n)
        {
            if (n == 0)
            {
                return true;
            }
            else return false;
        }
    }
    
}
