using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Muestra:IMuestra
    {
        IRepoLibro repoLibro;
        IRepoPrestamo repoPrestamo;
        public Muestra(IRepoLibro repoLibro,IRepoPrestamo repoPrestamo) 
        {
            this.repoLibro = repoLibro;
            this.repoPrestamo = repoPrestamo;

        }
        public void InventarioDeLibros()
        {
            var libros = repoLibro.TraerLista();
            var librosOrdenados = libros.OrderBy(p=>p.Titulo);

            foreach (Libro libro in librosOrdenados)
            {
                Console.WriteLine("Nombre: {0}", libro.Titulo);
                Console.WriteLine("Autor: {0}", libro.Autor);
                Console.WriteLine("Genero: {0}", libro.Genero);
                Console.WriteLine("");
            }
           
        }
        public void LibrosPorAutor(string autor)
        {
            var libros = repoLibro.TraerLista();

            var librosConMismoAutor = libros
                .Where(p => autor == p.Autor)
                .OrderBy(p => p.Titulo);


            foreach (Libro libro in librosConMismoAutor)
            {
                Console.WriteLine("Nombre: {0}", libro.Titulo);
                Console.WriteLine("");
            }

        }
        public void LibrosPorGenero(string genero)
        {
            var libros = repoLibro.TraerLista();

            var librosConMismoGenero = libros
                .Where(p => genero == p.Genero)
                .OrderBy(p => p.Titulo);

            foreach (Libro libro in librosConMismoGenero)
            {
                Console.WriteLine("Nombre: {0}", libro.Titulo);
                Console.WriteLine("");
            }           
        }

        public void LibrosPrestados(Usuario usuario)
        {
            var prestamos = repoPrestamo.TraerLista();

            var librosPrestados = prestamos
                .Where(p => p.Cliente == usuario)
                .OrderBy(p => p.LibroAPrestar.Titulo);


            foreach (Prestamo libro in librosPrestados)
            {
                Console.WriteLine("Nombre: {0}", libro.LibroAPrestar.Titulo);
                Console.WriteLine("");
            }

        }      

    }
}
