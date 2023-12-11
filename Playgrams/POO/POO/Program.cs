﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            var instanciadora = new Instanciadora();
            instanciadora.Instanciar();

            IInicio inicio = instanciadora.ObtenerInstanciaInicio();
            inicio.Iniciar();


        }
    }
}
