using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CAgregarLibro
    {        
        CPedir pedir = new CPedir();

        public void AgregarLibro(CLibro[] plibro)
        {
            var t = "";
            var a = "";
            var g = "";
            Console.WriteLine("Cual es el titulo del libro?");
            t = pedir.pedircadena();
            Console.WriteLine("Quien es el autor?");
            a = pedir.pedircadena();
            Console.WriteLine("A que genero literario pertenece\n1. Drama\n2. Ficcion\n" +
                "3. Misterio\n4. Romance\n5. Autoayuda");
            g = pedir.pedircadena();
            for (int n = 0; n < plibro.Length; n++)
            {
                if (plibro[n] == null)
                {
                    plibro[n] = new CLibro(t.ToLower(), a.ToLower(), g.ToLower());
                    break;
                   
                }
            }
        }
    }
}
