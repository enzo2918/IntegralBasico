using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.Exceptions
{
    public class InputInvalidaException : Exception
    {
        public string DatoIngresadoInvalido;
        public InputInvalidaException(string mensaje, string datoIngresadoInvalido) : base(mensaje)
        {
            DatoIngresadoInvalido = datoIngresadoInvalido;
        }
    }
}
