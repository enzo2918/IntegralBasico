using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class RetiroLibro
    {
        Buscador buscador = new Buscador();
        Muestra muestra = new Muestra();
        Pedir pedir = new Pedir();
        public void Retiro(Libro[] libros,Usuario usuario, Prestamo[] prestamos)
        {
            
            Libro libroARetirar = null;
            string categoria;

            Console.WriteLine("Por cual categoria deseas buscar tu libro:\n" +
            "1. Titulo\n2. Autor\n3. Genero\n4. Inventario completo\n5. Salir");
            categoria = pedir.PedirCadena();
            switch (categoria)
            {
                case "1":
                    libroARetirar = RetiroPorTitulo(libros);
                    break;
                case "2":
                    libroARetirar = RetiroPorAutor(libros);
                    break;
                case "3":
                    libroARetirar = RetiroPorGenero(libros);
                    break;
                case "4":
                    libroARetirar = RetiroPorInventario(libros);
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Su seleccion es incorrecta");
                    break;

            }

            var libroYaRetirado = LibroYaRetirado(libroARetirar, prestamos);
            if (libroARetirar != null)
            {
                if (libroYaRetirado) Console.WriteLine("Este libro se encuentra en posesion de otra persona");                
                else PrestarLibro(usuario,libroARetirar,prestamos);
            }

        }
        private Libro RetiroPorTitulo(Libro[] libros)
        {
            Console.WriteLine("Cual es el titulo del libro que buscas?");
            var titulo = pedir.PedirCadena();
            var libroARetirar = buscador.BuscarLibro(titulo, libros);
            if (libroARetirar != null) return libroARetirar;
            else
            {
                Console.WriteLine("No contamos con este libro en nuestra biblioteca");
                return null;
            }

        }
             
        private Libro RetiroPorAutor(Libro[] libros)
        {
            Console.WriteLine("Cual es el autor del libro que buscas?");
            var autor = pedir.PedirCadena();
            muestra.MuestraAutor(autor, libros);
            Console.WriteLine("Que libro deseas?");
            var titulo = pedir.PedirCadena();
            var libroARetirar = buscador.BuscarLibro(titulo, libros);
            if (libroARetirar != null) return libroARetirar;
            else
            {
                Console.WriteLine("No contamos con este libro en nuestra biblioteca");
                return null;
            }
        }
        private Libro RetiroPorGenero(Libro[] libros)
        {
            Console.WriteLine("Que genero literario buscas:\nDrama\nFiccion\nMisterio\nRomance\nAutoayuda");
            var genero = pedir.PedirCadena();
            muestra.MuestraGeneros(genero, libros);
            Console.WriteLine("Que libro deseas?");
            var titulo = pedir.PedirCadena();
            var libroARetirar = buscador.BuscarLibro(titulo, libros);
            if (libroARetirar != null) return libroARetirar;
            else
            {
                Console.WriteLine("No contamos con este libro en nuestra biblioteca");
                return null;
            }
        }
        private Libro RetiroPorInventario(Libro[] libros)
        {
            muestra.MuestraInventario(libros);
            Console.WriteLine("\nCual libro deseas retirar?");
            var titulo = pedir.PedirCadena();
            var libroARetirar = buscador.BuscarLibro(titulo, libros);
            if (libroARetirar != null) return libroARetirar;
            else
            {
                Console.WriteLine("No contamos con este libro en nuestra biblioteca");
                return null;
            }
        }
        private bool LibroYaRetirado(Libro libroARetirar, Prestamo[] prestamos)
        {
            if (libroARetirar != null)
            {
                for (int n = 0; n < prestamos.Length; n++)
                {
                    if (prestamos[n] != null)
                    {
                        if (prestamos[n].LibroAPrestar == libroARetirar)
                        {
                            return true;
                        }
                    }
                }
            }               
            return false;
        }
        
        private void PrestarLibro(Usuario usuario,Libro libroARetirar, Prestamo[] prestamos)
        {
            for (int n =0;n< prestamos.Length; n++)
            {
                if (prestamos[n] == null)
                {
                    DateTime fechaDePrestamo = DateTime.Now;
                    prestamos[n] = new Prestamo(usuario, libroARetirar, fechaDePrestamo);
                    Console.WriteLine("Su pedido fue hecho exitosamente, recuerde devolver el libro {0}, antes de los siguientes 30 dias " +
                        "a partir de la fecha {1}/{2}/{3}", libroARetirar.Titulo, fechaDePrestamo.Day,fechaDePrestamo.Month,fechaDePrestamo.Year);
                    break;
                }
                
            }
        }
    }
}
