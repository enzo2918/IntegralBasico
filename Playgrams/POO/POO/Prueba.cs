using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Prueba
    {
        public CLibro[] libro =new CLibro[10];

        public Prueba(string pt, string pa, string pg)
        {
            for (int n = 0; n < libro.Length; n++)
            {
                if (libro[n] == null)
                {
                    Console.WriteLine(n);
                    libro[n] = new CLibro(pt.ToLower(), pa.ToLower(), pg.ToLower());
                    break;
                }
            }
        }

        public void muestra()
        {
            Console.WriteLine("{0}", libro[0].ATitulo);
        }

    }
}
