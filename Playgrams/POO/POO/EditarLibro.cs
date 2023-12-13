using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class EditarLibro:IEditarLibro
    {
        IMuestra muestra;
        IPedir pedir;
        IRepoLibro repoLibro;

        public EditarLibro(IMuestra muestraParametro, IPedir pedirParametro, IRepoLibro RepoLibro) 
        {
            muestra = muestraParametro;
            pedir = pedirParametro;
            repoLibro = RepoLibro;

        }
        public void Editar(List<Libro> libros) 
        {
            Console.WriteLine("Que libro deseas editar?");
            muestra.MuestraInventario(libros);
            var libroAEditar = pedir.PedirCadena();

            Editarlo(libroAEditar.ToLower());
        }
        private void Editarlo(string libroAEditar)
        {
            var libro = repoLibro.BuscarLibro(libroAEditar);

            if (libro != null)
            {
                Console.WriteLine("Que deseas modificar:\n1. Titulo: {0}\n2. Autor: {1}\n3. Genero: {2}", libro.Titulo, libro.Autor, libro.Genero);
                var eleccion = pedir.PedirCadena();

                if (eleccion == "1" || eleccion.ToLower() == "titulo")
                {
                    Console.WriteLine("Cual es el nuevo Titulo?");
                    var nuevoTitulo = pedir.PedirCadena();
                    var libroYaExiste = repoLibro.LibroExistente(nuevoTitulo);
                    if (libroYaExiste)
                    {
                        Console.WriteLine("Este tiutlo ya existe");
                        return;
                    }

                    repoLibro.EditarTitulo(libro, nuevoTitulo);

                }
                else if (eleccion == "2" || eleccion.ToLower() == "autor")
                {
                    Console.WriteLine("Cual es el nuevo Autor?");
                    var nuevoAutor = pedir.PedirCadena();
                    repoLibro.EditarAutor(libro, nuevoAutor);


                }
                else if (eleccion == "3" || eleccion.ToLower() == "genero")
                {
                    Console.WriteLine("Cual es el nuevo Genero?");
                    var nuevoGenero = pedir.PedirCadena();
                    repoLibro.EditarGenero(libro, nuevoGenero);

                }
                else Console.WriteLine("Su seleccion es incorrecta");
            }
            else Console.WriteLine("El libro seleccionado no existe");
            

        }

    }
}
