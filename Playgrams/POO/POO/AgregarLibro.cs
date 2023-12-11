using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class AgregarLibro:IAgregarLibro
    {        
        IPedir pedir;
        IBuscador buscador;
        public AgregarLibro(IPedir pedirParametro, IBuscador buscadorParametro) 
        {
            pedir = pedirParametro;
            buscador = buscadorParametro;
        }
        public void Agregar(List<Libro> libros)
        {
            Console.WriteLine("Cual es el titulo del libro?");
            var titulo = pedir.PedirCadena();

            var libroYaExiste = buscador.LibroExistente(titulo,libros);
            if (libroYaExiste)
            {
                Console.WriteLine("Este titulo ya existe");
                return;
            }

            Console.WriteLine("Quien es el autor?");
            var autor = pedir.PedirCadena();


            Console.WriteLine("A que genero literario pertenece\nDrama\nFiccion\n" +
                "Misterio\nRomance\nAutoayuda");
            var genero = PedirGenero();
            

            Crearlo(titulo, autor, genero, libros);

            
        }

        private string PedirGenero()
        {
            var genero = "";
            bool generoCorrecto = false;

            do
            {
                genero = pedir.PedirCadena();
                if (genero.ToLower() == "drama" || genero == "ficcion" || genero == "misterio" || genero == "romance" || genero == "autoayuda")
                {
                    generoCorrecto = true;
                }
                else Console.WriteLine("Escriba el genero correctamente");

            } while (!generoCorrecto);

            return genero;
        }
        private void Crearlo(string titulo, string autor, string genero, List<Libro> libros)
        {
            libros.Add(new Libro(titulo.ToLower(), autor.ToLower(), genero.ToLower()));

            //for (int n = 0; n < libros.Count; n++)
            //{
            //    if (libros[n] == null)
            //    {
            //        libros[n] = new Libro(titulo.ToLower(), autor.ToLower(), genero.ToLower());
            //        break;
            //    }
            //}
        }
        
    }
}
