using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.Exceptions
{
    public class EstudianteInexistenteException : Exception
    {
        public string DatoIngresadoInvalido;
        public EstudianteInexistenteException(string mensaje, string datoIngresadoInvalido) : base(mensaje)
        {
            DatoIngresadoInvalido = datoIngresadoInvalido;
        }
    }
}
