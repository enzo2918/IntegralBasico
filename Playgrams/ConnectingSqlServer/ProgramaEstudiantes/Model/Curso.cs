using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    public class Curso
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public bool Archivado { set; get; }
        public int IdEscuela { set; get; }
        public Escuela Escuela { set; get; }
        public ICollection<EstudianteCurso> EstudiantesCursos { set; get; }
        public override string ToString()
        {
            return $"Nombre Curso: {Name}";
        }
    }
}
