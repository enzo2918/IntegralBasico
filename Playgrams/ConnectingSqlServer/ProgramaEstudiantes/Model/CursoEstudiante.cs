using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    internal class CursoEstudiante
    {
        public string NombreEstudiante {  get; set; }
        public string NombreCurso { get; set; }
        public int IdCurso { get; set; }
        public DateTime? FechaInscripcion { get; set; }
    }
}
