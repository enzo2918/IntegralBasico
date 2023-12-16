using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IRepoLibro
    {

        List<Libro> TraerLista();
        void Añadir(Libro libro);
        bool TituloYaExiste(string titulo);
        Libro Buscar(string libroABuscar);
        void Modificar(Libro libro);
        void Borrar(Libro libroAEliminar);
    }
}
