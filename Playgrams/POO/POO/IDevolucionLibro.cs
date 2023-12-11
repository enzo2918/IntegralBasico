using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IDevolucionLibro
    {
        void Devolucion(List<Prestamo> prestamos, List<Libro> libros, Usuario usuario);
    }
}
