using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Muestra:IMuestra
    {
        public void MuestraInventario(Libro[] libros)
        {
            OrdenarAlfabeticamente(libros);

            for (int n = 0; n < libros.Length; n++)
            {               
                for (int m = 0; m < libros.Length; m++)
                {
                    if (libros[m] != null && libros[m].Posicion == n)
                    {
                        Console.WriteLine("Nombre: {0}",libros[m].Titulo);
                        Console.WriteLine("Autor: {0}", libros[m].Autor);
                        Console.WriteLine("Genero: {0}", libros[m].Genero);
                        Console.WriteLine("");
                    }
                }                                  
            }
        }
        public void MuestraAutor(string autor,Libro[] libros)
        {
            for (int n = 0; n < libros.Length; n++)
            {
                if (libros[n] != null)
                {
                    if (autor == libros[n].Autor)
                    Console.WriteLine(libros[n].Titulo);
                }

            }
        }
        public void MuestraGeneros(string genero,Libro[] libros)
        {
            for (int n = 0; n < libros.Length; n++)
            {
                if (libros[n] != null)
                {
                    if (genero == libros[n].Genero)
                        Console.WriteLine(libros[n].Titulo);
                }

            }
        }

        public void MuestraLibrosPrestados(Prestamo[] prestamos,Usuario usuario)
        {
            for(int n = 0; n < prestamos.Length; n++)
            {
                if (prestamos[n] != null && prestamos[n].Cliente == usuario) Console.WriteLine(prestamos[n].LibroAPrestar.Titulo);
            }
        }
        private void OrdenarAlfabeticamente(Libro[] libros)
        {
            for (int a = 0; a < libros.Length; a++)
            {
                if (libros[a] != null)
                {
                    libros[a].Posicion = 0;
                }
            }
            for (int n =0; n < libros.Length; n++)
            {
                if (libros[n] != null)
                {
                    for (int m = 0; m < libros.Length; m++)
                    {
                        if (libros[m] != null)
                        {
                            if (libros[n] != libros[m])
                            {
                                var contador = 0;
                                for (int l = 0; l < libros[n].Titulo.Length && l < libros[m].Titulo.Length; l++)
                                {    
                                    
                                    if (libros[n].Titulo[l] > libros[m].Titulo[l])
                                    {
                                        libros[n].Posicion = libros[n].Posicion + 1;
                                        break;
                                    }
                                    else if (libros[n].Titulo[l] < libros[m].Titulo[l]) break;
                                    contador++;                                    
                                }
                                if (contador == libros[m].Titulo.Length) libros[n].Posicion++;
                            }
                        }
                        

                    }
                }
                
            }
        }

    }
}
