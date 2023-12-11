using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collection_list
{
    internal class List
    {
        static void Main(string[] args)
        {
            List<int> lista1 = new List<int>();
            for ( int n = 0; n < 8; n++)
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



            List<punto> lista2 = new List<punto>();
        }
    }
}
