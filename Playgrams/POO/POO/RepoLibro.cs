using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class RepoLibro : IRepoLibro
    {
        private List<Libro> libros = new List<Libro>();

        public List<Libro> TraerLista()
        {
            return libros;
        } 
       
        public void Añadir(Libro libro)
        {
            libros.Add(libro);
        }
        public bool TituloYaExiste(string titulo)
        {
            bool libroYaExiste = libros.Any(p => titulo == p.Titulo);
            return libroYaExiste;
        }
        public Libro Buscar(string libroABuscar)
        {
            Libro libroBuscado = libros.FirstOrDefault(p => libroABuscar == p.Titulo);
            return libroBuscado;
        }
        public void Modificar(Libro libro) 
        { 

        }
        
        public void Borrar(Libro libroAEliminar)
        {
            libros.Remove(libroAEliminar);

        }
    }
}
