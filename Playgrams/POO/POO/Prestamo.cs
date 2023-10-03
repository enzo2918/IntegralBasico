using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Prestamo
    {
        public Usuario Cliente { get; set; }
        public Libro LibroAPrestar { get; set; }
        public DateTime FechaDePrestamo { get; set; }
        public Prestamo(Usuario cliente, Libro libroAPrestar, DateTime fechaDePrestamo)
        {
            Cliente = cliente;
            LibroAPrestar = libroAPrestar;
            FechaDePrestamo = fechaDePrestamo;
        }
    }
}
