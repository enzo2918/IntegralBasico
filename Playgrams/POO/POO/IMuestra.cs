using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IMuestra
    {
        void MuestraInventario(Libro[] libros);
        void MuestraAutor(string autor, Libro[] libros);
        void MuestraGeneros(string genero, Libro[] libros);
        void MuestraLibrosPrestados(Prestamo[] prestamos, Usuario usuario);

    }
}
