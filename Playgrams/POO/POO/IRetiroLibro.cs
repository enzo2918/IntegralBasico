using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IRetiroLibro
    {
        void Retiro(List<Libro> libros, Usuario usuario, List<Prestamo> prestamos);
    }
}
