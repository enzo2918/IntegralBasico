using System.Collections.Generic;

namespace ProgramaEstudiantes.Repositorios
{
    public interface IEstudianteRepositorio
    {
        void ActualizarEstudiante(Estudiante estudiante);
        void DesvincularAlumnoCurso(int estudianteId, int cursoId);
        void DesvincularAlumnoDeTodosLosCursos(int estudianteId);
        void DesvincularAlumnoEscuela(int estudianteId);
        void EliminarEstudiante(int estudianteId);
        void InsertarEstudiante(string nombre, string dni, string telefono);
        Estudiante ObtenerEstudianteConRelaciones(string nombreDniEstudiante);
        List<Estudiante> ObtenerEstudiantes();
        void VincularAlumnoCursos(int estudianteId, int cursoId);
        void VincularAlumnoEscuela(int escuelaId, int estudianteId);
    }
}