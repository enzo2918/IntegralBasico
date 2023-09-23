using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CInventario
    {
        public void MuestraInventario(CLibro[] plibro)
        {
            for (int n = 0; n < plibro.Length; n++)
            {
                if (plibro[n] != null)
                {
                    Console.WriteLine(plibro[n].ATitulo);
                }

            }
        }
    }
}
