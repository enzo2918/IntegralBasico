using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class DevolucionLibro
    {
        Muestra muestra = new Muestra();
        Pedir pedir = new Pedir();
        
        public void Devolucion(Prestamo[] prestamos, Libro[] libros)
        {
            Console.WriteLine("Cual libro quieres devolver?");
            muestra.MuestraLibrosPrestados(prestamos);
            var tituloLibroADevolver = pedir.PedirCadena();

            Devolver(tituloLibroADevolver, libros, prestamos);

        }
        private void Devolver(string tituloLibroADevolver, Libro[] libros, Prestamo[] prestamos)
        {
            Buscador buscador = new Buscador();
            var libroADevolver = buscador.BuscarLibro(tituloLibroADevolver, libros);
            for (int n = 0; n < prestamos.Length; n++)
            {
                if (prestamos[n] != null)
                {
                    if (libroADevolver == prestamos[n].LibroAPrestar)
                    {
                        prestamos[n] = null;
                        Console.WriteLine("Gracias por su devolucion");
                        break;
                    }
                }
               

            }

        }
    }
}
