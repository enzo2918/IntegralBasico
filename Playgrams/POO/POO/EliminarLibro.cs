using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CEliminarLibro
    {
        Prueba blibro = new Prueba("putob", "", "");
        CPedir pedir = new CPedir();
        private string eleccion="";
        public void EliminarLibro()
        {
            var eleccion = "";
            Console.WriteLine("Que libro deseas eliminar?");
            MuestraInventario();
            eleccion = pedir.pedircadena();
            Eliminar(eleccion.ToLower());


        }
        private void MuestraInventario()
        {
            if (blibro.libro[0]  == null) { Console.WriteLine("fallaste"); }
            for (int n = 0; n< blibro.libro.Length; n++)
            {
                if (blibro.libro[n] != null)
                {
                    Console.WriteLine("entraste");
                    Console.WriteLine(n);
                    blibro.muestra();
                    
                }
                    
            }
        }
        private void Eliminar(string peleccion)
        {

            for (int n = 0;n< blibro.libro.Length; n++)
            {
                if (peleccion == blibro.libro[n].ATitulo)
                {
                    blibro.libro[n] = null;
                    break;
                }
            }
            
        }
    }
}
