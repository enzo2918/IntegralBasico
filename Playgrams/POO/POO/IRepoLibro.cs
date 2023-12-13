using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IRepoLibro
    {
        void Crearlo(string titulo, string autor, string genero);
        bool LibroExistente(string titulo);
        Libro BuscarLibro(string libroABuscar);
        void EditarTitulo(Libro libroAEditar, string nuevoTitulo);
        void EditarAutor(Libro libroAEditar, string nuevoAutor);
        void EditarGenero(Libro libroAEditar, string nuevoGenero);
        void EliminarLibro(Libro libroAEliminar);
    }
}
