using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public double Posicion { get; set; }    
        

        public Libro(string titulo, string autor, string genero)
        {
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
        }
    }
}
