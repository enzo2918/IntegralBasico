using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.Repositorios
{
    internal class EstudianteConsultasCrudasRepositorio : IEstudianteRepositorio
    {
        private IRepositorioSql _repo;

        public EstudianteConsultasCrudasRepositorio(IRepositorioSql repositorioSql)
        {
            _repo = repositorioSql;
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            var queryString = "Select * from estudiantes order by id";
            var estudiantes = _repo.DevolverDatosTabla(queryString, DevolverEstudiantes);
            return estudiantes;
        }
        public Estudiante ObtenerEstudianteConRelaciones(string nombreDniEstudiante)
        {
            var queryString = "Select est.id,est.name,est.dni,est.telefono,esc.name as 'escuela',ec.fechaInscripcion,c.id as 'idCurso',c.name as 'curso' from estudiantes est " +
                            "left join escuelas esc on est.idEscuela = esc.id " +
                            "left join estudianteCurso ec on est.id = ec.idEstudiante " +
                            "left join cursos c on c.id = ec.idCurso " +
                            "where (archivado = 0 or archivado is null) and est.id = (select top 1 est3.id from estudiantes est3 where name = @estudiante or dni = @estudiante) ";
            var parametros = new List<SqlParameter>() { CrearParametro("@estudiante", nombreDniEstudiante), };
            var estudiantes = _repo.DevolverDatosTabla(queryString, DevolverEstudianteDetallado, parametros);
            var estudiante = UnificarCursos(estudiantes);
            return estudiante;

        }

        public void InsertarEstudiante(string nombre, string dni, string telefono)
        {
            var queryString = $"insert into estudiantes (name,dni,telefono) values (@nombre,@dni,@telefono)";
            var parametros = new List<SqlParameter>()
            {
                CrearParametro("@nombre", nombre),
                CrearParametro("@dni", dni),
                CrearParametro("@telefono", telefono, true),
            };

            _repo.EjecutarQuery(queryString, parametros);
        }
        public void ActualizarEstudiante(Estudiante estudiante)
        {
            string queryStringUpdate = $"update estudiantes set name = {estudiante.Name}, dni = {estudiante.Dni}, telefono = {estudiante.Telefono} where id = {estudiante.Id}";
            _repo.EjecutarQuery(queryStringUpdate);
        }
        public void EliminarEstudiante(int estudianteId)
        {
            var queryString = $"delete from estudiantes where id = {estudianteId}";
            _repo.EjecutarQuery(queryString);
        }


        public void VincularAlumnoEscuela(int escuelaId, int estudianteId)
        {
            var queryString = $"update estudiantes set idEscuela = {escuelaId} where id = {estudianteId}";
            _repo.EjecutarQuery(queryString);
        }

        public void VincularAlumnoCursos(int estudianteId, int cursoId)
        {
            var queryString = $"insert into estudianteCurso (idEstudiante,idCurso,fechaInscripcion) " +
                $"values ({estudianteId},{cursoId},'{DateTime.Now}')";

            _repo.EjecutarQuery(queryString);
        }
        public void DesvincularAlumnoEscuela(int estudianteId)
        {
            var queryString = $"update estudiantes set idEscuela = null where id = {estudianteId}";
            _repo.EjecutarQuery(queryString);

        }
        public void DesvincularAlumnoDeTodosLosCursos(int estudianteId)
        {
            var queryStringCursos = $"delete from estudianteCurso where idEstudiante = {estudianteId}";
            _repo.EjecutarQuery(queryStringCursos);
        }

        public void DesvincularAlumnoCurso(int estudianteId, int cursoId)
        {
            var queryString = $"delete from estudianteCurso where idEstudiante = {estudianteId} and idCurso = {cursoId}";
            _repo.EjecutarQuery(queryString);
        }




        #region Mapeo Entidades

        private Estudiante DevolverEstudiantes(SqlDataReader reader)
        {
            string telefono = "No declarado";
            if (!(reader["telefono"] is DBNull)) telefono = reader["telefono"].ToString();
            int? idEscuela = null;
            if (!(reader["idEscuela"] is DBNull)) idEscuela = int.Parse(reader["idEscuela"].ToString());

            var estudiante = new Estudiante()
            {
                Id = int.Parse(reader["id"].ToString()),
                Name = reader["name"].ToString(),
                Dni = reader["dni"].ToString(),
                Telefono = telefono,
                IdEscuela = idEscuela
            };

            return estudiante;
        }
        private Estudiante DevolverEstudianteDetallado(SqlDataReader reader)
        {
            string telefono = null;
            DateTime? fechaInscripcion = null;
            if (!(reader["fechaInscripcion"] is DBNull)) fechaInscripcion = DateTime.Parse(reader["fechaInscripcion"].ToString());
            if (!(reader["telefono"] is DBNull)) telefono = reader["telefono"].ToString();


            var estudiante = new Estudiante()
            {
                Id = int.Parse(reader["id"].ToString()),
                Name = reader["name"].ToString(),
                Dni = reader["dni"].ToString(),
                Telefono = telefono,
                Escuela = reader["escuela"].ToString() == null ? null : new Escuela() { Name = reader["escuela"].ToString() },
                EstudiantesCursos = new List<EstudianteCurso>()
            };

            if (!(reader["idCurso"] is DBNull))
            {
                estudiante.EstudiantesCursos.Add(
                    new EstudianteCurso
                    {
                        Curso = new Curso { Name = reader["curso"].ToString() },
                        FechaInscripcion = fechaInscripcion
                    }
                );
            }

            return estudiante;
        }

        #endregion

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
        private Estudiante UnificarCursos(List<Estudiante> estudiantes)
        {
            if (estudiantes.Count == 0) return null;
            var estudiante = estudiantes.First();
            estudiante.EstudiantesCursos = estudiantes.SelectMany(est => est.EstudiantesCursos).ToList();

            return estudiante;
        }
    }
}
