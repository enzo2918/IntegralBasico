using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class RepoPrestamo:IRepoPrestamo
    {
        private List<Prestamo> prestamos = new List<Prestamo>();
        public List<Prestamo> TraerLista()
        {
            return prestamos;
        }

        public Prestamo Buscar(Libro libroADevolver, Usuario usuario)
        {
            var prestamoBuscado = prestamos.FirstOrDefault(p => libroADevolver == p.LibroAPrestar && p.Cliente == usuario);
            return prestamoBuscado;
        }
        public Prestamo Buscar(Libro libroARetirar)
        {
            var prestamoBuscado = prestamos.FirstOrDefault(p => p.LibroAPrestar == libroARetirar);
            return prestamoBuscado;
        }
        public void Borrar(Prestamo prestamo)
        {
            prestamos.Remove(prestamo);
        }
        public void Añadir(Prestamo prestamo)
        {
            prestamos.Add(prestamo);
        }
    }
}
