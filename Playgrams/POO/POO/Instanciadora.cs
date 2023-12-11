using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Instanciadora
    {
        IInicio inicio;
        public void Instanciar()
        {
            var usuarios = new List<Usuario>();
            var libros = new List<Libro>();
            var prestamos = new List<Prestamo>();

            Usuario usuarioAdministrador = new Usuario("Enzo Ortiz", "x", "x", true);
            usuarios.Insert(0, usuarioAdministrador);

            IBuscador buscador = new Buscador();
            IPedir pedir = new Pedir();
            IMuestra muestra = new Muestra();

            IAgregarLibro agrega = new AgregarLibro(pedir, buscador);
            IDevolucionLibro devuelve = new DevolucionLibro(muestra, pedir);
            IEditarLibro edita = new EditarLibro(buscador, muestra, pedir);
            IEliminarLibro elimina = new EliminarLibro(muestra, pedir);
            IIngreso ingreso = new Ingreso(usuarios, pedir);
            IRetiroLibro retira = new RetiroLibro(buscador, muestra, pedir);

            inicio = new Inicio(usuarios, libros, prestamos, pedir, agrega, devuelve, edita, elimina, ingreso, retira);

        }
        
        public IInicio ObtenerInstanciaInicio()
        {
            return inicio;
        }
    }
}
