using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    public class Input : IInput
    {
        public string Line()
        {
            var entrada = Console.ReadLine();
            return entrada;
        }
    }
}
