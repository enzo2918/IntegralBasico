using System.Collections.Generic;

namespace ProgramaEstudiantes
{
    public interface IObtener
    {
        Estudiante EstudianteDesdeElUsuario();
        List<Estudiante> EstudiantesYMostrarTodos();
        List<Escuela> EscuelasYMostrar();
        List<Curso> CursosPorEscuelaYMostrar(Estudiante estudiante);
    }
}