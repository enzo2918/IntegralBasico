using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class RetiroLibro:IRetiroLibro
    {
        IMuestra muestra;
        IPedir pedir;
        IRepoLibro repoLibro;
        IRepoPrestamo repoPrestamo;
        public RetiroLibro(IMuestra muestra, IPedir pedir, IRepoLibro repoLibro,IRepoPrestamo repoPrestamo)
        {
            this.muestra = muestra;
            this.pedir = pedir;
            this.repoLibro = repoLibro;
            this.repoPrestamo  = repoPrestamo; 
        }
        public void Retiro(Usuario usuario)
        {
            Console.WriteLine("hola pepe putito");
            Libro libroARetirar;
            string categoria;
            string tituloLibro = "";

            Console.WriteLine("Por cual categoria deseas buscar tu libro:\n" +
            "1. Titulo\n2. Autor\n3. Genero\n4. Inventario completo\n5. Salir");
            categoria = pedir.Cadena();

            switch (categoria)
            {
                case "1":
                    tituloLibro = PorTitulo();
                    break;
                case "2":
                    tituloLibro = PorAutor();
                    break;
                case "3":
                    tituloLibro = porGenero();
                    break;
                case "4":
                    tituloLibro = PorInventario();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Su seleccion es incorrecta");
                    break;

            }

            libroARetirar = BuscarLibro(tituloLibro);

            if (libroARetirar != null)
            {
                var libroYaRetirado = LibroYaRetirado(libroARetirar,usuario);

                if (libroYaRetirado== "YaPrestadoAOtro") Console.WriteLine("Este libro se encuentra en posesion de otra persona"); 
                else if (libroYaRetirado == "YaPrestado") Console.WriteLine("Este libro ya se encuentra en tu posesion");

                else Retirar(usuario,libroARetirar);
            }

        }
        private string PorTitulo()
        {
            Console.WriteLine("Cual es el titulo del libro que buscas?");
            var titulo = pedir.Cadena();
            return titulo;

        }
             
        private string PorAutor()
        {
            Console.WriteLine("Cual es el autor del libro que buscas?");
            var autor = pedir.Cadena();
            muestra.LibrosPorAutor(autor);
            Console.WriteLine("Que libro deseas?");
            var titulo = pedir.Cadena();
            return titulo;
        }
        private string porGenero()
        {
            Console.WriteLine("Que genero literario buscas:\nDrama\nFiccion\nMisterio\nRomance\nAutoayuda");
            var genero = pedir.Cadena();
            muestra.LibrosPorGenero(genero);
            Console.WriteLine("Que libro deseas?");
            var titulo = pedir.Cadena();
            return titulo;
        }
        private string PorInventario()
        {
            muestra.InventarioDeLibros();
            Console.WriteLine("\nCual libro deseas retirar?");
            var titulo = pedir.Cadena();
            return titulo;
            
        }
        private Libro BuscarLibro(string titulo)
        {
            var libroARetirar = repoLibro.Buscar(titulo);
            if (libroARetirar != null) return libroARetirar;
            else
            {
                Console.WriteLine("No contamos con este libro en nuestra biblioteca");
                return null;
            }
        }
        private string LibroYaRetirado(Libro libroARetirar,Usuario usuario)
        {
            var Prestamo = repoPrestamo.Buscar(libroARetirar);
            if (Prestamo != null)
            {
                if (Prestamo.Cliente != usuario) return "YaPrestadoAOtro";
                else return "YaPrestado";
            }
            else return "Disponible";           
        }
        
        private void Retirar(Usuario usuario,Libro libroARetirar)
        {
            DateTime fechaDePrestamo = DateTime.Now;
            Prestamo prestamo = new Prestamo(usuario, libroARetirar, fechaDePrestamo);
            repoPrestamo.Añadir(prestamo);
            Console.WriteLine("Su pedido fue hecho exitosamente, recuerde devolver el libro {0}, antes de los siguientes 30 dias " +
                        "a partir de la fecha {1}/{2}/{3}", libroARetirar.Titulo, fechaDePrestamo.Day, fechaDePrestamo.Month, fechaDePrestamo.Year);

        }
    }
}
