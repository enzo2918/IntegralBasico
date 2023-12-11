using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ClaseExplicita
    {
        private static string[] postres = { "manzana", "caramelo", "lemon pie", "manzana caramelizada" };

        private static IEnumerable<string> encontrarPostresDeManzana = from n in postres
                                                                       where n.Contains("manzana")
                                                                       select n;
        public static IEnumerable<string> PostresDeManzana()
        { 
            return encontrarPostresDeManzana; 
        }

        public static List<int> EnterosPares()
        {
            var enteros = new List<int> { 11,12,13,14,15,16,17,18,19,20};
            enteros.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            IEnumerable<int> enterosPares = from n in enteros
                                            where n%2 == 0
                                            select n;

            return enterosPares.ToList();
        }

        public static int[] EnterosImpares()
        {
            var enteros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var enterosImpares = from n in enteros
                                 where n % 2 != 0
                                 select n;

            return enterosImpares.ToArray();
        }
    }
}
