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
        IRepoLibro repoLibro;
        public EliminarLibro(IMuestra muestraParametro, IPedir pedirParametro,IRepoLibro RepoLibro)
        {
            muestra = muestraParametro;
            pedir = pedirParametro;
            repoLibro = RepoLibro;
        }
        public void Eliminar(List<Libro> libros)
        {
            Console.WriteLine("Que libro deseas eliminar?");

            muestra.MuestraInventario(libros);
            var libroAEliminar = pedir.PedirCadena();

            Eliminarlo(libroAEliminar.ToLower());
        }
       
        private void Eliminarlo(string libroAEliminar)
        {
            var libro = repoLibro.BuscarLibro(libroAEliminar);
            if (libro != null)
            {
                repoLibro.EliminarLibro(libro);
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
