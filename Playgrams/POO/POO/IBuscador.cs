using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IBuscador
    {
        Libro BuscarLibro(string libroABuscar, Libro[] libros);
        bool LibroExistente(string titulo, Libro[] libros);
    }
}
