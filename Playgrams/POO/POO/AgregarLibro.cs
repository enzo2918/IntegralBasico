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
        IRepoLibro repoLibro;
        
        public AgregarLibro(IPedir pedir, IRepoLibro repoLibro) 
        {
            this.pedir = pedir;
            this.repoLibro = repoLibro;
        }

        public void Agregacion()
        {
            Console.WriteLine("Ingrese el titulo del libro?");
            var tituloLibro = pedir.Cadena();

            var tituloYaExiste = repoLibro.TituloYaExiste(tituloLibro);
            if (tituloYaExiste)
            {
                Console.WriteLine("Este titulo ya existe");
                return;
            }

            Console.WriteLine("Quien es el autor?");
            var autorLibro = pedir.Cadena();


            Console.WriteLine("A que genero literario pertenece\nDrama\nFiccion\n" +
                "Misterio\nRomance\nAutoayuda");
            var generoLibro = PedirGenero();

            var nuevoLibro = new Libro(tituloLibro.ToLower(), autorLibro.ToLower(), generoLibro.ToLower());
            repoLibro.Añadir(nuevoLibro);

            
        }

        private string PedirGenero()
        {
            string generoLibro;
            bool generoCorrecto = false;

            do
            {
                generoLibro = pedir.Cadena();
                if (generoLibro.ToLower() == "drama" || generoLibro == "ficcion" || generoLibro == "misterio" || generoLibro == "romance" || generoLibro == "autoayuda")
                {
                    generoCorrecto = true;
                }
                else Console.WriteLine("Escriba el genero correctamente");

            } while (!generoCorrecto);

            return generoLibro;
        }
        
        
    }
}
