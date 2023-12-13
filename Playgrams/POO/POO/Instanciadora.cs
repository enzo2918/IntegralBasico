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

            IRepoLibro repoLibro = new RepoLibro(libros);
            IRepoPrestamo repoPrestamo = new RepoPrestamo(prestamos);
            IRepoUsuario repoUsuario = new RepoUsuario(usuarios);

            Usuario usuarioAdministrador = new Usuario("Enzo", "x", "x", true);
            usuarios.Add(usuarioAdministrador);

            IPedir pedir = new Pedir();
            IMuestra muestra = new Muestra();

            IAgregarLibro agrega = new AgregarLibro(pedir,repoLibro);
            IDevolucionLibro devuelve = new DevolucionLibro(muestra, pedir,repoPrestamo,repoLibro);
            IEditarLibro edita = new EditarLibro(muestra, pedir,repoLibro);
            IEliminarLibro elimina = new EliminarLibro(muestra, pedir,repoLibro);
            IIngreso ingreso = new Ingreso(pedir,repoUsuario);
            IRetiroLibro retira = new RetiroLibro(muestra, pedir,repoLibro,repoPrestamo);

            inicio = new Inicio(libros, prestamos, pedir, agrega, devuelve, edita, elimina, ingreso, retira);

        }
        
        public IInicio ObtenerInstanciaInicio()
        {
            return inicio;
        }
    }
}
