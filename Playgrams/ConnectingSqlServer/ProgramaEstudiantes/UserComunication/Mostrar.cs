using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProgramaEstudiantes
{
    public class Mostrar : IMostrar
    {
        private IOutput _output;

        public Mostrar (IOutput output)
        {
            _output = output;
        }

        public void EstudianteSimplificado(Estudiante estudiante)
        {
            _output.Line($"Nombre: {estudiante.Name}, Dni: {estudiante.Dni}");
        }

        public void EstudianteCompleto(Estudiante estudiante)
        {
            _output.Line(ObtenerEstudianteCompleto(estudiante));
        }

        public void EstudianteYRelaciones(Estudiante estudiante)
        {
            _output.Line(ObtenerEstudianteCompleto(estudiante) + $", Escuela: {estudiante.Escuela?.Name}");

            foreach (var ce in estudiante.EstudiantesCursos)
            {
                string fechaInscripcion = ce.FechaInscripcion.HasValue ? ce.FechaInscripcion.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                                                       : "No declarada";
                _output.Line($"Curso: {ce.Curso.Name}, Fecha de inscripcion: {fechaInscripcion}");
            }
            _output.Line();
        }

        private string ObtenerEstudianteCompleto(Estudiante estudiante)
        {
            if (estudiante.Telefono == null) estudiante.Telefono = "No declarado";
            return $"ID: {estudiante.Id}, Nombre: {estudiante.Name}, Dni: {estudiante.Dni}, Telefono: {estudiante.Telefono}";
        }

        public void Escuela(Escuela escuela)
        {
            _output.Line($"Nombre: {escuela.Name}");
        }

        public void CursosEstudiante(List<EstudianteCurso> cursosEstudiante)
        {
            _output.Line("Cursos inscriptos del estudiante:");

            foreach (var ce in cursosEstudiante)
            {
                _output.Line(ce.Curso.Name);
            }
            _output.Line();
        }
    }
}
