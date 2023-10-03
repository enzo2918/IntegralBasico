﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class EditarLibro
    {
        Buscador buscador = new Buscador();
        Muestra inventario = new Muestra();
        Pedir pedir = new Pedir();
        public void Editar(Libro[] libros) 
        {
            Console.WriteLine("Que libro deseas editar?");
            inventario.MuestraInventario(libros);
            var libroAEditar = pedir.PedirCadena();

            Editarlo(libroAEditar.ToLower(),libros);
        }
        private void Editarlo(string libroAEditar, Libro[] libros)
        {
            var libro = buscador.BuscarLibro(libroAEditar, libros);

            if (libro != null)
            {
                Console.WriteLine("Que deseas modificar:\n1. Titulo: {0}\n2. Autor: {1}\n3. Genero: {2}", libro.Titulo, libro.Autor, libro.Genero);
                var eleccion = pedir.PedirCadena();

                if (eleccion == "1" || eleccion.ToLower() == "titulo")
                {
                    Console.WriteLine("Cual es el nuevo Titulo?");
                    var nuevoTitulo = pedir.PedirCadena();
                    var libroYaExiste = LibroExistente(nuevoTitulo, libros);
                    if (libroYaExiste)
                    {
                        Console.WriteLine("Este tiutlo ya existe");
                        return;
                    }
                    libro.Titulo = nuevoTitulo;
                }
                else if (eleccion == "2" || eleccion.ToLower() == "autor")
                {
                    Console.WriteLine("Cual es el nuevo Autor?");
                    var nuevoAutor = pedir.PedirCadena();
                    libro.Autor = nuevoAutor;

                }
                else if (eleccion == "3" || eleccion.ToLower() == "genero")
                {
                    Console.WriteLine("Cual es el nuevo Genero?");
                    var nuevoGenero = pedir.PedirCadena();
                    libro.Genero = nuevoGenero;
                }
                else Console.WriteLine("Su seleccion es incorrecta");
            }
            else Console.WriteLine("El libro seleccionado no existe");
            

        }
        

        private bool LibroExistente(string titulo, Libro[] libros)
        {
            var libroYaExiste = false;
            for (int n = 0; n < libros.Length; ++n)
            {
                if (libros[n] != null)
                {
                    if (titulo == libros[n].Titulo)
                    {
                        libroYaExiste = true;
                        break;

                    }
                }
            }
            return libroYaExiste;
        }

    }
}
