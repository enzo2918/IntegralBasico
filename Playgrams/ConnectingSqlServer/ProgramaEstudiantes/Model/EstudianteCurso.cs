using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    public class EstudianteCurso
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public int IdEstudiante { get; set; }
        public DateTime? FechaInscripcion { get; set; }
        public Estudiante Estudiante { get; set; }
        public Curso Curso { get; set; }
    }
}
