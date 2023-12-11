using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Buscador:IBuscador
    {
        public Libro BuscarLibro(string libroABuscar, List<Libro> libros)
        {
            Libro libroADevolver = libros.Where(p => libroABuscar == p.Titulo).FirstOrDefault();
            
            //for (int n = 0; n < libros.Count; n++)
            //{
            //    if (libros[n] != null)
            //    {
            //        if (libroABuscar == libros[n].Titulo)
            //        {
            //            libroADevolver = libros[n];
            //            break;
            //        }
            //    }
            //}
            return libroADevolver;
        }
        public bool LibroExistente(string titulo, List<Libro> libros)
        {
            bool libroYaExiste = libros.Any(p => titulo == p.Titulo);

            //var libroYaExiste = false;
            //for (int n = 0; n < libros.Count; ++n)
            //{
            //    if (libros[n] != null)
            //    {
            //        if (titulo == libros[n].Titulo)
            //        {
            //            libroYaExiste = true;
            //            break;

            //        }
            //    }
            //}
            return libroYaExiste;

        }

    }
}