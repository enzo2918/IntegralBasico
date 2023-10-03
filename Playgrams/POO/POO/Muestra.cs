using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Muestra
    {
        public void MuestraInventario(Libro[] libros)
        {
            for (int n = 0; n < libros.Length; n++)
            {
                if (libros[n] != null)
                {
                    Console.WriteLine(libros[n].Titulo);
                }

            }
        }
        public void MuestraAutor(string autor,Libro[] libros)
        {
            for (int n = 0; n < libros.Length; n++)
            {
                if (libros[n] != null)
                {
                    if (autor == libros[n].Autor)
                    Console.WriteLine(libros[n].Titulo);
                }

            }
        }
        public void MuestraGeneros(string genero,Libro[] libros)
        {
            for (int n = 0; n < libros.Length; n++)
            {
                if (libros[n] != null)
                {
                    if (genero == libros[n].Genero)
                        Console.WriteLine(libros[n].Titulo);
                }

            }
        }

        public void MuestraLibrosPrestados(Prestamo[] prestamos)
        {
            for(int n = 0; n < prestamos.Length; n++)
            {
                if (prestamos[n] != null) Console.WriteLine(prestamos[n].LibroAPrestar.Titulo);
            }
        }

    }
}
