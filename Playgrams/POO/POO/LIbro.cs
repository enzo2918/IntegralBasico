using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CLibro
    {
        private string Titulo { get; }
        private string Autor { get; }
        private string Genero { get; }

        //public CLibro[] libro = new CLibro[10];

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
        }
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("{0} {1} {2}",Titulo, Autor, Genero);
            return cadena.ToString();
        }




    }
}
