using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.Repositorios.EF
{
    internal class CursoEFRepositorio : ICursoRepositorio
    {
        public List<EstudianteCurso> ObtenerCursosEstudiante(int estudianteId)
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var estudianteCursos = BDEstudiantes.EstudiantesCursos.Include(ec => ec.Curso).Where(ec => ec.IdEstudiante == estudianteId).ToList();
                return estudianteCursos;
            }
        }
        public List<Curso> ObtenerCursosPorEscuela(int escuelaId)
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var cursos = BDEstudiantes.Cursos.Where(c => c.IdEscuela == escuelaId).ToList();
                return cursos;
            }


        }
    }
}
