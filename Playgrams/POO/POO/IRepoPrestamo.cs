using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IRepoPrestamo
    {
        Prestamo BuscarPrestamo(Libro libroADevolver, Usuario usuario);

        void Devolver(Prestamo prestamo);
        Prestamo LibroYaPrestado(Libro libroARetirar);
        void PrestarLibro(Usuario usuario, Libro libroARetirar, DateTime fechaDePrestamo);
    }
}
