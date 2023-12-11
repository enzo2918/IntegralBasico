using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class EliminarLibro:IEliminarLibro
    {
        IMuestra muestra;
        IPedir pedir;
        public EliminarLibro(IMuestra muestraParametro, IPedir pedirParametro)
        {
            muestra = muestraParametro;
            pedir = pedirParametro;
        }
        public void Eliminar(List<Libro> libros)
        {
            Console.WriteLine("Que libro deseas eliminar?");

            muestra.MuestraInventario(libros);
            var eleccion = pedir.PedirCadena();

            Eliminarlo(eleccion.ToLower(), libros);
        }
       
        private void Eliminarlo(string peleccion, List<Libro> libros )
        {
            var libro = libros.FirstOrDefault(p => peleccion == p.Titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                Console.WriteLine("El libro ha sido eliminado");
            }
            else Console.WriteLine("El libro que desea eliminar no existe");

            //for (int n = 0;n< libros.Count; n++)
            //{
            //    if (libros[n] != null)
            //    {
            //        if (peleccion == libros[n].Titulo)
            //        {
            //            libros[n] = null;
            //            return;
            //        }
            //    }
                
            //}
            //Console.WriteLine("Este libro no existe");
            
        }
    }
}
