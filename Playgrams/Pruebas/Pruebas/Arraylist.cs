using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecttions_arraylist
{
    internal class Arraylist
    {
        static void Main(string[] args)
        {
            object num = 1;
            Console.WriteLine(num);
            num = "hola";
            Console.WriteLine(num);

            ArrayList numeros = new ArrayList();
            for (int a = 0; a < 5; a++)
            {
                numeros.Add(a);
                int r = (int)numeros[a];
                Console.WriteLine(numeros[r]);
            }
            ArrayList palabras = new ArrayList();

            palabras.Add("h");
            palabras.Add(0);
            palabras.Add("puto");

            Console.WriteLine(palabras[0]);
            Console.WriteLine(palabras[1]);

            palabras.AddRange(numeros);
            palabras.Add("hola");
            foreach (dynamic r in palabras) { Console.WriteLine("{0}", r); }

            Console.WriteLine(palabras.Contains("h"));
            Console.WriteLine(palabras.Contains(10));
            Console.WriteLine(palabras.Contains("4"));
            Console.WriteLine(palabras.Contains(4));

            palabras.Insert(2, "puto");
            Console.WriteLine("------------");
            foreach (dynamic r in palabras) { Console.WriteLine("{0}", r); }

            palabras.Insert(2, "y ahora");
            Console.WriteLine("------------");
            foreach (dynamic r in palabras) { Console.WriteLine("{0}", r); }

            palabras.Remove("puto");
            palabras.Remove("puto");
            Console.WriteLine("------------");
            foreach (dynamic r in palabras) { Console.WriteLine("{0}", r); }

            palabras.RemoveAt(0);
            Console.WriteLine("------------");
            foreach (dynamic r in palabras) { Console.WriteLine("{0}", r); }


            List<int> lista1 = new List<int>();
            for (int n = 0; n < 8; n++)
            {
                lista1.Add(n);
                lista1.Add(n - 2);
            }
            foreach (int n in lista1)
            {
                Console.WriteLine(n);
            }

            lista1.Sort();
            foreach (int n in lista1)
            {
                Console.WriteLine(n);
            }


        }
    }
}
