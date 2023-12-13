using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class RepoLibro : IRepoLibro
    {
        List<Libro> libros;
        public RepoLibro(List<Libro> Libros)
        {
            libros = Libros;

        }
        public void Crearlo(string titulo, string autor, string genero)
        {
            libros.Add(new Libro(titulo.ToLower(), autor.ToLower(), genero.ToLower()));
        }
        public bool LibroExistente(string titulo)
        {
            bool libroYaExiste = libros.Any(p => titulo == p.Titulo);
            return libroYaExiste;
        }
        public Libro BuscarLibro(string libroABuscar)
        {
            Libro libroADevolver = libros.FirstOrDefault(p => libroABuscar == p.Titulo);
            return libroADevolver;
        }

        public void EditarTitulo(Libro libroAEditar, string nuevoTitulo)
        {
            libroAEditar.Titulo = nuevoTitulo;
        }
        public void EditarAutor(Libro libroAEditar, string nuevoAutor)
        {
            libroAEditar.Autor = nuevoAutor;
        }
        public void EditarGenero(Libro libroAEditar, string nuevoGenero)
        {
            libroAEditar.Genero = nuevoGenero;
        }
        public void EliminarLibro(Libro libroAEliminar)
        {
            libros.Remove(libroAEliminar);

        }
    }
}
