using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CRetiroLibro
    {
        CPedir pedir = new CPedir();
        public void RetiroLibro(CLibro[] plibro)
        {
            var eleccion = "";
            Console.WriteLine("Por cual categoria deseas buscar tu libro:\n" +
                "1. Titulo\n2. Autor\n3. Genero\n4. Inventario completo");
            eleccion = pedir.pedircadena();
            
        }
    }
}
