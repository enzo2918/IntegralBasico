using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    public class Escuela
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Estudiante> Estudiantes{ get; set; }
        public ICollection<Curso> Cursos { get; set; }
        public override string ToString()
        {
            return $"Nombre: {Name}";
        }
    }
}
