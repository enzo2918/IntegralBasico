using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class RepoPrestamo:IRepoPrestamo
    {
        List<Prestamo> prestamos;
        public RepoPrestamo(List<Prestamo> Prestamos) 
        {
            prestamos = Prestamos;
        }
        public Prestamo BuscarPrestamo(Libro libroADevolver, Usuario usuario)
        {
            var prestamo = prestamos.FirstOrDefault(p => libroADevolver == p.LibroAPrestar && p.Cliente == usuario);
            return prestamo;
        }
        public Prestamo LibroYaPrestado(Libro libroARetirar)
        {
            var Prestamo = prestamos.FirstOrDefault(p => p.LibroAPrestar == libroARetirar);
            return Prestamo;
        }
        public void Devolver(Prestamo prestamo)
        {
            prestamos.Remove(prestamo);
        }
        public void PrestarLibro(Usuario usuario, Libro libroARetirar, DateTime fechaDePrestamo)
        {
            prestamos.Add(new Prestamo(usuario, libroARetirar, fechaDePrestamo));
        }
    }
}
