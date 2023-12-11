using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Muestra:IMuestra
    {
        public void MuestraInventario(List<Libro> libros)
        {
            var librosOrdenados = libros.OrderBy(p=>p.Titulo);



            foreach (Libro n in librosOrdenados)
            {
                Console.WriteLine("Nombre: {0}", n.Titulo);
                Console.WriteLine("Autor: {0}", n.Autor);
                Console.WriteLine("Genero: {0}", n.Genero);
                Console.WriteLine("");
            }

            //OrdenarAlfabeticamente(libros);

            //for (int n = 0; n < libros.Count; n++)
            //{               
            //    for (int m = 0; m < libros.Count; m++)
            //    {
            //        if (libros[m] != null && libros[m].Posicion == n)
            //        {
            //            Console.WriteLine("Nombre: {0}",libros[m].Titulo);
            //            Console.WriteLine("Autor: {0}", libros[m].Autor);
            //            Console.WriteLine("Genero: {0}", libros[m].Genero);
            //            Console.WriteLine("");
            //        }
            //    }                                  
            //}
        }
        public void MuestraAutor(string autor, List<Libro> libros)
        {
            var librosConMismoAutor = libros
                .Where(p => autor == p.Autor)
                .OrderBy(p => p.Titulo);


            foreach (Libro n in librosConMismoAutor)
            {
                Console.WriteLine("Nombre: {0}", n.Titulo);
                Console.WriteLine("");
            }

            //for (int n = 0; n < libros.Count; n++)
            //{
            //    if (libros[n] != null)
            //    {
            //        if (autor == libros[n].Autor)
            //        Console.WriteLine(libros[n].Titulo);
            //    }

            //}
        }
        public void MuestraGeneros(string genero, List<Libro> libros)
        {
            var librosConMismoGenero = libros
                .Where(p => genero == p.Genero)
                .OrderBy(p => p.Titulo);

            foreach (Libro n in librosConMismoGenero)
            {
                Console.WriteLine("Nombre: {0}", n.Titulo);
                Console.WriteLine("");
            }

            //for (int n = 0; n < libros.Count; n++)
            //{
            //    if (libros[n] != null)
            //    {
            //        if (genero == libros[n].Genero)
            //            Console.WriteLine(libros[n].Titulo);
            //    }

            //}
        }

        public void MuestraLibrosPrestados(List<Prestamo> prestamos,Usuario usuario)
        {
            var librosPrestados = prestamos
                .Where(p => p.Cliente == usuario)
                .OrderBy(p => p.LibroAPrestar.Titulo);


            foreach (Prestamo n in librosPrestados)
            {
                Console.WriteLine("Nombre: {0}", n.LibroAPrestar.Titulo);
                Console.WriteLine("");
            }


            //for (int n = 0; n < prestamos.Count; n++)
            //{
            //    if (prestamos[n] != null && prestamos[n].Cliente == usuario) Console.WriteLine(prestamos[n].LibroAPrestar.Titulo);
            //}
        }


        //private void OrdenarAlfabeticamente(List<Libro> libros)
        //{
        //    for (int a = 0; a < libros.Count; a++)
        //    {
        //        if (libros[a] != null)
        //        {
        //            libros[a].Posicion = 0;
        //        }
        //    }
        //    for (int n =0; n < libros.Count; n++)
        //    {
        //        if (libros[n] != null)
        //        {
        //            for (int m = 0; m < libros.Count; m++)
        //            {
        //                if (libros[m] != null)
        //                {
        //                    if (libros[n] != libros[m])
        //                    {
        //                        var contador = 0;
        //                        for (int l = 0; l < libros[n].Titulo.Length && l < libros[m].Titulo.Length; l++)
        //                        {    
                                    
        //                            if (libros[n].Titulo[l] > libros[m].Titulo[l])
        //                            {
        //                                libros[n].Posicion = libros[n].Posicion + 1;
        //                                break;
        //                            }
        //                            else if (libros[n].Titulo[l] < libros[m].Titulo[l]) break;
        //                            contador++;                                    
        //                        }
        //                        if (contador == libros[m].Titulo.Length) libros[n].Posicion++;
        //                    }
        //                }
                        

        //            }
        //        }
                
        //    }
        //}

    }
}
