﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Buscador
    {
        public Libro BuscarLibro(string libroABuscar, Libro[] libros)
        {
            Libro libroADevolver = null;
            for (int n = 0; n < libros.Length; n++)
            {
                if (libros[n] != null)
                {
                    if (libroABuscar == libros[n].Titulo)
                    {
                        libroADevolver = libros[n];
                        break;
                    }
                }
            }
            return libroADevolver;
        }
    }
}
