using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    internal class Estudiante
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dni { get; set;}
        public string Telefono { get; set;}
        public string Escuela { get; set;}
        public int? IdEscuela { get; set;}
        public List<CursoEstudiante> CursosEstudiantes { get; set;}



        public void MostrarSimplificado()
        {
            Console.WriteLine($"Nombre: {Name}, Dni: {Dni}");
        }

        public void MostrarCompleto()
        {
            Console.WriteLine(ObtenerEstudianteCompleto());
        }

        public void MostrarDetallado()
        {           
            Console.WriteLine(ObtenerEstudianteCompleto() + $" Escuela: {Escuela}");

            foreach (var ce in CursosEstudiantes)
            {
                string fechaInscripcion = ce.FechaInscripcion.HasValue ? ce.FechaInscripcion.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                                                       : "No declarada";
                Console.WriteLine($"Curso: {ce.NombreCurso}, Fecha de inscripcion: {fechaInscripcion}");
            }
            Console.WriteLine();
        }

        private string ObtenerEstudianteCompleto()
        {
            if (Telefono == null) Telefono = "No declarado";
            return $"ID: {Id}, Nombre: {Name}, Dni: {Dni}, Telefono: {Telefono}";
        }
    }
    
}
