using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IRetiroLibro
    {
        void Retiro(Libro[] libros, Usuario usuario, Prestamo[] prestamos);
    }
}
