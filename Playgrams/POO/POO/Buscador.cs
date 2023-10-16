using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Buscador:IBuscador
    {
        public Libro BuscarLibro(string libroABuscar, Libro[] libros)
        {
            Libro libroADevolver = null;
            for (int n = 0; n < libros.Length; n++)
            {
                if (libros[n] != null)
                {
                    if (libroABuscar == libros[n].Titulo)
                    {
                        libroADevolver = libros[n];
                        break;
                    }
                }
            }
            return libroADevolver;
        }
        public bool LibroExistente(string titulo, Libro[] libros)
        {
            var libroYaExiste = false;
            for (int n = 0; n < libros.Length; ++n)
            {
                if (libros[n] != null)
                {
                    if (titulo == libros[n].Titulo)
                    {
                        libroYaExiste = true;
                        break;

                    }
                }
            }
            return libroYaExiste;

        }

    }
}