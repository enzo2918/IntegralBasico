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
        public EliminarLibro(IMuestra muestra, IPedir pedir,IRepoLibro repoLibro)
        {
            this.muestra = muestra;
            this.pedir = pedir;
            this.repoLibro = repoLibro;
        }
        public void Eliminacion()
        {
            Console.WriteLine("Que libro deseas eliminar?");

            muestra.InventarioDeLibros();
            var libroAEliminar = pedir.Cadena();

            Eliminar(libroAEliminar.ToLower());
        }
       
        private void Eliminar(string libroAEliminar)
        {
            var libro = repoLibro.Buscar(libroAEliminar);

            if (libro != null)
            {
                repoLibro.Borrar(libro);
                Console.WriteLine("El libro ha sido eliminado");
            }
            else Console.WriteLine("El libro que desea eliminar no existe");          
            
        }
    }
}
