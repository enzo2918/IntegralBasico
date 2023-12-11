using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class DevolucionLibro:IDevolucionLibro
    {
        IMuestra muestra;
        IPedir pedir;
        
        public DevolucionLibro(IMuestra muestraParametro, IPedir pedirParamtro) 
        {
            muestra = muestraParametro;
            pedir = pedirParamtro;
        }
        public void Devolucion(List<Prestamo> prestamos, List<Libro> libros,Usuario usuario)
        {
            Console.WriteLine("Cual libro quieres devolver?");
            muestra.MuestraLibrosPrestados(prestamos,usuario);
            var tituloLibroADevolver = pedir.PedirCadena();

            Devolver(tituloLibroADevolver, libros, prestamos,usuario);

        }
        private void Devolver(string tituloLibroADevolver, List<Libro> libros, List<Prestamo> prestamos, Usuario usuario)
        {
            Buscador buscador = new Buscador();
            var libroADevolver = buscador.BuscarLibro(tituloLibroADevolver, libros);

            if (libroADevolver == null) 
            {
                Console.WriteLine("No se encuentra el libro proporcionado");
            }
            else 
            {
                var prestamo = prestamos.FirstOrDefault(p => libroADevolver == p.LibroAPrestar && p.Cliente == usuario);
                if (prestamo != null) 
                {
                    var devolucion = prestamos.Remove(prestamo);
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

        }
    }
}
