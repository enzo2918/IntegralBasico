using ProgramaEstudiantes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    public class Pedir : IPedir
    {
        private IInput _input;
        public Pedir(IInput input)
        {
            _input = input;
        }
        public int Entero(string mensaje, (int, int) rangoValido)
        {
            Console.WriteLine(mensaje);
            var datoIngresado = _input.Line();

            int opcionElegida;
            var datoEsEntero = int.TryParse(datoIngresado, out opcionElegida);
            if (!datoEsEntero)
            {
                throw new InputInvalidaException("El dato ingresado debe ser un numero", datoIngresado);
            }

            if (opcionElegida < rangoValido.Item1 || opcionElegida > rangoValido.Item2)
            {
                throw new FueraDeRangoException("El dato ingresado no se encuentra entre las opciones", datoIngresado);
            }

            return opcionElegida;
        }

        public string Cadena(string mensaje)
        {
            Console.WriteLine(mensaje);
            var datoIngresado = _input.Line();
            return datoIngresado;
        }
    }
}
