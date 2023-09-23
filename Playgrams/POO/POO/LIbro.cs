using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CLibro
    {
        private string Titulo { get; set; }
        private string Autor { get; set; }
        private string Genero { get; set; }

        public CLibro(string ptitulo, string pautor, string pgenero)
        {
            Titulo = ptitulo;
            Autor = pautor;
            Genero = pgenero;
        }

        public string ATitulo
        {
            get
            {
                return Titulo;
            }
            set
            {
                Titulo = value;
            }
        }
        public string AAutor
        {
            get
            {
                return Autor;
            }
            set
            {
                Autor = value;
            }
        }
        public string AGenero
        {
            get
            {
                return Genero;
            }
            set
            {
                Genero = value;
            }
        }
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("{0} {1} {2}",Titulo, Autor, Genero);
            return cadena.ToString();
        }




    }
}
