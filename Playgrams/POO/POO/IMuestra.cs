using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IMuestra
    {
        void InventarioDeLibros();
        void LibrosPorAutor(string autor);
        void LibrosPorGenero(string genero);
        void LibrosPrestados(Usuario usuario);

    }
}
