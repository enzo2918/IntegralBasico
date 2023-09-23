using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CEliminarLibro
    {
        CInventario inventario = new CInventario();
        CPedir pedir = new CPedir();
        private string eleccion="";
        public void EliminarLibro(CLibro[] plibro)
        {
            var eleccion = "";
            Console.WriteLine("Que libro deseas eliminar?");
            inventario.MuestraInventario(plibro);
            eleccion = pedir.pedircadena();
            Eliminar(eleccion.ToLower(), plibro);


        }
       
        private void Eliminar(string peleccion, CLibro[] plibro )
        {

            for (int n = 0;n< plibro.Length; n++)
            {
                if (peleccion == plibro[n].ATitulo)
                {
                    plibro[n] = null;
                    break;
                }
            }
            
        }
    }
}
