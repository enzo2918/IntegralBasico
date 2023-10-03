using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class EliminarLibro
    {
        Muestra inventario = new Muestra();
        Pedir pedir = new Pedir();
        public void Eliminar(Libro[] libros)
        {
            Console.WriteLine("Que libro deseas eliminar?");

            inventario.MuestraInventario(libros);
            var eleccion = pedir.PedirCadena();

            Eliminarlo(eleccion.ToLower(), libros);
        }
       
        private void Eliminarlo(string peleccion, Libro[] libros )
        {

            for (int n = 0;n< libros.Length; n++)
            {
                if (libros[n] != null)
                {
                    if (peleccion == libros[n].Titulo)
                    {
                        libros[n] = null;
                        return;
                    }
                }
                
            }
            Console.WriteLine("Este libro no existe");
            
        }
    }
}
