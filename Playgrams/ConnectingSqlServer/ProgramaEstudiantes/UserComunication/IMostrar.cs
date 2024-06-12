using System.Collections.Generic;

namespace ProgramaEstudiantes
{
    public interface IMostrar
    {
        void EstudianteCompleto(Estudiante estudiante);
        void EstudianteSimplificado(Estudiante estudiante);
        void EstudianteYRelaciones(Estudiante estudiante);
        void Escuela(Escuela escuela);
        void CursosEstudiante(List<EstudianteCurso> cursosEstudiante);
    }
}