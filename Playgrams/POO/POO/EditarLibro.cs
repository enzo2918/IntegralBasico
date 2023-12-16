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

        public EditarLibro(IMuestra muestra, IPedir pedir, IRepoLibro repoLibro) 
        {
            this.muestra = muestra;
            this.pedir = pedir;
            this.repoLibro = repoLibro;

        }
        public void Edicion() 
        {
            Console.WriteLine("Que libro deseas editar?");
            muestra.InventarioDeLibros();
            var libroAEditar = pedir.Cadena();

            Editar(libroAEditar.ToLower());
        }
        private void Editar(string libroAEditar)
        {
            var libro = repoLibro.Buscar(libroAEditar);

            if (libro != null)
            {
                Console.WriteLine("Que deseas modificar:\n1. Titulo: {0}\n2. Autor: {1}\n3. Genero: {2}", libro.Titulo, libro.Autor, libro.Genero);
                var eleccion = pedir.Cadena();

                if (eleccion == "1" || eleccion.ToLower() == "titulo")
                {
                    Console.WriteLine("Cual es el nuevo Titulo?");
                    var nuevoTitulo = pedir.Cadena();
                    var tituloYaExiste = repoLibro.TituloYaExiste(nuevoTitulo);

                    if (tituloYaExiste)
                    {
                        Console.WriteLine("Este titulo ya existe");
                        return;
                    }

                    libro.Titulo = nuevoTitulo;
                    repoLibro.Modificar(libro);

                }
                else if (eleccion == "2" || eleccion.ToLower() == "autor")
                {
                    Console.WriteLine("Cual es el nuevo Autor?");
                    var nuevoAutor = pedir.Cadena();

                    libro.Autor = nuevoAutor;
                    repoLibro.Modificar(libro);

                }
                else if (eleccion == "3" || eleccion.ToLower() == "genero")
                {
                    Console.WriteLine("Cual es el nuevo Genero?");
                    var nuevoGenero = pedir.Cadena();

                    libro.Genero = nuevoGenero;
                    repoLibro.Modificar(libro);

                }
                else Console.WriteLine("Su seleccion es incorrecta");
            }
            else Console.WriteLine("El libro seleccionado no existe");
            

        }

    }
}
