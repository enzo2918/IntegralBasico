using System.Collections.Generic;

namespace ProgramaEstudiantes.Repositorios
{
    public interface ICursoRepositorio
    {
        List<EstudianteCurso> ObtenerCursosEstudiante(int estudianteId);
        List<Curso> ObtenerCursosPorEscuela(int escuelaId);
    }
}