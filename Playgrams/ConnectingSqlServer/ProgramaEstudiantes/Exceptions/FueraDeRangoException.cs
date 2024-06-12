using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    public class FueraDeRangoException : Exception
    {
        public string DatoIngresadoInvalido;
        public FueraDeRangoException(string mensaje,string datoIngresadoInvalido) : base(mensaje) 
        {
            DatoIngresadoInvalido = datoIngresadoInvalido;
        }
    }
}
