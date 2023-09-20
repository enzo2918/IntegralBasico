using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CAgregarLibro
    {
        Prueba alibro = new Prueba("putoa","","");
        
        CPedir pedir = new CPedir();

        public void AgregarLibro()
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
            for (int n = 0; n < alibro.libro.Length; n++)
            {
                if (alibro.libro[n] == null)
                {
                    Console.WriteLine(n);
                    alibro = new Prueba(t, a, g);
                    alibro = new Prueba("bbb", a, g);
                    alibro.muestra();
                    break;
                   
                }
            }
        }
    }
}
