using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IRepoPrestamo
    {
        List<Prestamo> TraerLista();
        Prestamo Buscar(Libro libroADevolver, Usuario usuario);

        void Borrar(Prestamo prestamo);
        Prestamo Buscar(Libro libroARetirar);
        void Añadir(Prestamo prestamo);
    }
}
