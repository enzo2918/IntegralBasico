using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class DevolucionLibro : IDevolucionLibro
    {
        IMuestra muestra;
        IPedir pedir;
        IRepoPrestamo repoPrestamo;
        IRepoLibro repoLibro;

        public DevolucionLibro(IMuestra muestraParametro, IPedir pedirParamtro, IRepoPrestamo RepoPrestamo, IRepoLibro RepoLibro)
        {
            muestra = muestraParametro;
            pedir = pedirParamtro;
            repoPrestamo = RepoPrestamo;
            repoLibro = RepoLibro;
        }
        public void Devolucion(List<Prestamo> prestamos, Usuario usuario)
        {
            Console.WriteLine("Cual libro quieres devolver?");
            muestra.MuestraLibrosPrestados(prestamos, usuario);
            var tituloLibroADevolver = pedir.PedirCadena();


            var libroADevolver = repoLibro.BuscarLibro(tituloLibroADevolver);

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
                var prestamo = repoPrestamo.BuscarPrestamo(libroADevolver, usuario);

                if (prestamo != null)
                {
                    repoPrestamo.Devolver(prestamo);
                    Console.WriteLine("Gracias por su devolucion");
                }
                else Console.WriteLine("Este libro no se encuentra en su posesion");
            }




            //for (int n = 0; n < prestamos.Count; n++)
            //{
            //    if (prestamos[n] != null)
            //    {
            //        if (libroADevolver == prestamos[n].LibroAPrestar && prestamos[n].Cliente == usuario)
            //        {
            //            prestamos[n] = null;
            //            Console.WriteLine("Gracias por su devolucion");
            //            break;
            //        }
            //    }
            //}

            //}
        }
    }
}
