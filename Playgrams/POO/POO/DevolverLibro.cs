using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class DevolverLibro : IDevolverLibro
    {
        IMuestra muestra;
        IPedir pedir;
        IRepoPrestamo repoPrestamo;
        IRepoLibro repoLibro;

        public DevolverLibro(IMuestra muestra, IPedir pedir, IRepoPrestamo repoPrestamo, IRepoLibro repoLibro)
        {
            this.muestra = muestra;
            this.pedir = pedir;
            this.repoPrestamo = repoPrestamo;
            this.repoLibro = repoLibro;
        }
        public void Devolucion(Usuario usuario)
        {
            Console.WriteLine("Que libro quieres devolver?");
            muestra.LibrosPrestados(usuario);
            var tituloLibroADevolver = pedir.Cadena();


            var libroADevolver = repoLibro.Buscar(tituloLibroADevolver);

            Devolver(libroADevolver, usuario);

        }



        private void Devolver(Libro libroADevolver, Usuario usuario)
        {

            if (libroADevolver == null)
            {
                Console.WriteLine("No se encuentra el libro proporcionado");
            }
            else
            {
                var prestamo = repoPrestamo.Buscar(libroADevolver, usuario);

                if (prestamo != null)
                {
                    repoPrestamo.Borrar(prestamo);
                    Console.WriteLine("Gracias por su devolucion");
                }
                else Console.WriteLine("Este libro no se encuentra en su posesion");
            }

        }
    }
}
