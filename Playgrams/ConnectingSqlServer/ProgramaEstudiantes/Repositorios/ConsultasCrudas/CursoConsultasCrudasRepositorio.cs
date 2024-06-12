using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.Repositorios
{
    internal class CursoConsultasCrudasRepositorio : ICursoRepositorio
    {
        private IRepositorioSql _repo;

        public CursoConsultasCrudasRepositorio(IRepositorioSql repositorioSql)
        {
            _repo = repositorioSql;
        }

        public List<Curso> ObtenerCursosPorEscuela(int escuelaId)
        {
            var queryString = $"Select * from cursos where idEscuela = @idEscuela and archivado = 0 order by name";
            var parametros = new List<SqlParameter>() { CrearParametro("@idEscuela", escuelaId.ToString(), true) };
            var cursos = _repo.DevolverDatosTabla(queryString, DevolverCursos, parametros);
            return cursos;
        }
        public List<EstudianteCurso> ObtenerCursosEstudiante(int estudianteId)
        {
            var queryString = "Select c.name as nameCurso, c.id as idCurso from estudianteCurso ec " +
                "join cursos c on ec.idCurso = c.id " +
                $"where ec.idEstudiante = {estudianteId}";
            var cursosEstudiante = _repo.DevolverDatosTabla(queryString, DevolverEstudianteCurso);
            return cursosEstudiante;
        }
        private SqlParameter CrearParametro(string nombreParametro, string valorParametro, bool nulleable = false)
        {
            if (string.IsNullOrWhiteSpace(valorParametro))
            {
                if (!nulleable)
                    throw new Exception("Error de datos");

                return new SqlParameter(nombreParametro, DBNull.Value);
            }
            else
                return new SqlParameter(nombreParametro, valorParametro);
        }

        private Curso DevolverCursos(SqlDataReader reader)
        {
            var curso = new Curso()
            {
                Id = int.Parse(reader["id"].ToString()),
                Name = reader["name"].ToString(),
                Archivado = bool.Parse(reader["archivado"].ToString()),
                IdEscuela = int.Parse(reader["idEscuela"].ToString())
            };
            return curso;

        }
        private EstudianteCurso DevolverEstudianteCurso(SqlDataReader reader)
        {
            return new EstudianteCurso
            {
                Curso = new Curso { Name = reader["nameCurso"].ToString() },
                IdCurso = int.Parse(reader["idCurso"].ToString()),
            };
        }

    }
}
