using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    public class Output : IOutput
    {
        public void Line(string mensaje = null)
        {
            Console.WriteLine(mensaje);
        }
    }
}
