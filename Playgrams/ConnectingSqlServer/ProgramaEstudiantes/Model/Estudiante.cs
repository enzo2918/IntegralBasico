using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dni { get; set;}
        public string Telefono { get; set;}
        public int? IdEscuela { get; set;}

        public Escuela Escuela { get; set;}
        public ICollection<EstudianteCurso> EstudiantesCursos { get; set;}
        
    }
    
}
