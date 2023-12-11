using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IMuestra
    {
        void MuestraInventario(List<Libro> libros);
        void MuestraAutor(string autor, List<Libro> libros);
        void MuestraGeneros(string genero, List<Libro> libros);
        void MuestraLibrosPrestados(List<Prestamo> prestamos, Usuario usuario);

    }
}
