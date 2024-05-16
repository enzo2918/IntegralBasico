using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    internal class Inicio
    {
        private RepositorioSql _repo;

        public Inicio()
        {
            _repo = new RepositorioSql();
        }

        public void IniciarPrograma()
        {

            int accionARealizar;

            do
            {
                Console.WriteLine("Seleccione la opcion que desee realizar:\n" +
                    "1. Consultar todos los estudiantes\n" +
                    "2. Consultar un estudiante en detalle\n" +
                    "3. Agregar un estudiante\n" +
                    "4. Modificar un estudiante\n" +
                    "5. Eliminar un estudiante\n" +
                    "6. Inscribir estudiante a una escuela\n" +
                    "7. Inscribir estudiante a un curso\n" +
                    "8. Desinscribir estudiante de una escuela\n" +
                    "9. Desinscribir estudiante de un curso\n" +
                    "10. Salir");
                Console.WriteLine();

                accionARealizar = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (accionARealizar)
                {
                    case 1:
                        MostrarTodosEstudiantes();
                        break;
                    case 2:
                        ConsultarEstudianteEnDetalle();
                        break;
                    case 3:
                        InsertarEstudiante();
                        break;
                    case 4:
                        ModificarEstudiante();
                        break;
                    case 5:
                        EliminarEstudiante();
                        break;
                    case 6:
                        VincularAlumnoEscuela();
                        break;
                    case 7:
                        VincularAlumnoCursos();
                        break;
                    case 8:
                        DesinscribirAlumnoEscuela();
                        break;
                    case 9:
                        DesinscribirAlumnoCurso();
                        break;
                }

            } while (accionARealizar != 10);

        }


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
        private CursoEstudiante DevolverEstudianteCurso(SqlDataReader reader)
        {
            return new CursoEstudiante
            {
                NombreCurso = reader["nameCurso"].ToString(),
                IdCurso = int.Parse(reader["idCurso"].ToString()),
            };
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
                Escuela = reader["escuela"].ToString(),
                CursosEstudiantes = new List<CursoEstudiante>()
            };

            if (!(reader["idCurso"] is DBNull))
            {
                estudiante.CursosEstudiantes.Add(
                    new CursoEstudiante
                    {
                        NombreCurso = reader["curso"].ToString(),
                        NombreEstudiante = reader["name"].ToString(),
                        FechaInscripcion = fechaInscripcion
                    }
                );
            }

            return estudiante;
        }

        private Escuela DevolverEscuelas(SqlDataReader reader)
        {
            var escuela = new Escuela() 
            { 
                Name = reader["name"].ToString() ,
                Id = int.Parse(reader["id"].ToString())
            };
            return escuela;
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

        private void MostrarTodosEstudiantes()
        {
            var queryString = "Select * from estudiantes order by id";
            var estudiantes = _repo.DevolverDatosTabla(queryString, DevolverEstudiantes);
            foreach (var estudiante in estudiantes)
            {
                estudiante.MostrarSimplificado();
            }
            Console.WriteLine();
        }
        private List<Estudiante> MostrarYTraerTodosEstudiantes()
        {
            var queryString = "Select * from estudiantes order by id";
            var estudiantes = _repo.DevolverDatosTabla(queryString, DevolverEstudiantes);
            foreach (var estudiante in estudiantes)
            {
                estudiante.MostrarSimplificado();
            }
            Console.WriteLine();
            return estudiantes;
        }

        

        private void InsertarEstudiante()
        {
            Console.WriteLine("Cual es el nombre del estudiante?");
            var nombre = Console.ReadLine();
            Console.WriteLine("Cual es su numero de DNI?");
            var dni = Console.ReadLine();
            Console.WriteLine("Cual es su numero de telefono?");
            var telefono = Console.ReadLine();
            var queryString = $"insert into estudiantes (name,dni,telefono) values (@nombre,@dni,@telefono)";
            var parametros = new List<SqlParameter>()
            {
                CrearParametro("@nombre", nombre),
                CrearParametro("@dni", dni),
                CrearParametro("@telefono", telefono, true),
            };

            _repo.EjecutarQuery(queryString, parametros);
            Console.WriteLine();
        }

        private void ModificarEstudiante()
        {
            var estudiante = TraerYMostrarEstudiantePorDni();
            if (estudiante == null) return;

            Console.WriteLine("Que categoria desea modificar:\n1. Nombre\n2. DNI\n3. Telefono");
            var columnaAModificar = int.Parse(Console.ReadLine());
            Console.WriteLine($"Cual es el nuevo valor?");
            var nuevoValorColumna = Console.ReadLine();

            string queryStringUpdate;
            var parametrosUpdate = new List<SqlParameter>();
            switch (columnaAModificar)
            {
                case 1:
                    queryStringUpdate = $"update estudiantes set name = @valorParametro where id = {estudiante.Id}";
                    parametrosUpdate.Add(CrearParametro("@valorParametro", nuevoValorColumna));
                    break;
                case 2:
                    queryStringUpdate = $"update estudiantes set dni = @valorParametro where id = {estudiante.Id}";
                    parametrosUpdate.Add(CrearParametro("@valorParametro", nuevoValorColumna));
                    break;
                case 3:
                    queryStringUpdate = $"update estudiantes set telefono = @valorParametro where id = {estudiante.Id}";
                    parametrosUpdate.Add(CrearParametro("@valorParametro", nuevoValorColumna, true));
                    break;
                default:
                    return;
            }

            

            _repo.EjecutarQuery(queryStringUpdate, parametrosUpdate);
            Console.WriteLine($"Registro modificado");
            Console.WriteLine();
        }

        private void ConsultarEstudianteEnDetalle()
        {
            MostrarTodosEstudiantes();
            Console.WriteLine("Que estudiante deseas ver en detalle? Escribe el nombre o el dni");
            var nombreDniEstudiante = Console.ReadLine();            
            var queryString = "Select est.id,est.name,est.dni,est.telefono,esc.name as 'escuela',ec.fechaInscripcion,c.id as 'idCurso',c.name as 'curso' from estudiantes est " +
                            "left join escuelas esc on est.idEscuela = esc.id " +
                            "left join estudianteCurso ec on est.id = ec.idEstudiante " +
                            "left join cursos c on c.id = ec.idCurso " +
                            "where (archivado = 0 or archivado is null) and est.id = (select top 1 est3.id from estudiantes est3 where name = @estudiante or dni = @estudiante) ";
            var parametros = new List<SqlParameter>() { CrearParametro("@estudiante", nombreDniEstudiante), };
            var estudiantes = _repo.DevolverDatosTabla(queryString, DevolverEstudianteDetallado, parametros);
            var estudiante = UnificarCursos(estudiantes);
            if (estudiante != null) estudiante.MostrarDetallado();
        }

        private void VincularAlumnoEscuela()
        {
            var estudiantes = MostrarYTraerTodosEstudiantes();
            Console.WriteLine("Que estudiante deseas inscribir? Escribe el nombre o el dni");
            var nombreDniEstudiante = Console.ReadLine();
            var estudiante = estudiantes.FirstOrDefault(est => est.Name.Equals(nombreDniEstudiante, StringComparison.InvariantCultureIgnoreCase)
                                                             || est.Dni.ToString().Equals(nombreDniEstudiante, StringComparison.InvariantCultureIgnoreCase));
            if (estudiante == null)
            {
                Console.WriteLine("Este estudiante no existe");
                return;
            }
            if (estudiante.IdEscuela != null)
            {
                Console.WriteLine("Este estudiante ya esta inscripto en otra escuela");
                return;

            }
            Console.WriteLine();

            var escuelas = TraerYMostrarTodasLasEscuelas();
            Console.WriteLine("A que escuela lo quieres vincular?");
            var nombreEscuela = Console.ReadLine();
            var escuela = (escuelas).FirstOrDefault(esc => esc.Name.Equals(nombreEscuela, StringComparison.InvariantCultureIgnoreCase));
            if (escuela == null)
            {
                Console.WriteLine("Esta escuela no existe");
                return;
            }
            Console.WriteLine();

            var queryString = $"update estudiantes set idEscuela = {escuela.Id} where id = {estudiante.Id}";
            
            _repo.EjecutarQuery(queryString);
            Console.WriteLine($"Alumno inscripto correctamente");
            Console.WriteLine();
        }

        private void VincularAlumnoCursos()
        {
            var estudiantes = MostrarYTraerTodosEstudiantes();
            Console.WriteLine("Que estudiante deseas vincular? Escribe el nombre o el dni");
            var nombreDniEstudiante = Console.ReadLine();
            var estudiante = estudiantes.FirstOrDefault(est => est.Name.Equals(nombreDniEstudiante, StringComparison.InvariantCultureIgnoreCase) 
                                                             || est.Dni.ToString().Equals(nombreDniEstudiante, StringComparison.InvariantCultureIgnoreCase));
            if (estudiante == null)
            {
                Console.WriteLine("Este estudiante no existe");
                return;
            }
            Console.WriteLine();

            var cursos = TraerYMostrarTodosLosCursosPorEscuela(estudiante);
            if (cursos == null) return;
            var cursosEstudiante = ConsultarCursosEstudiante(estudiante.Id);
            if (cursosEstudiante != null) MostrarCursosEstudiante(cursosEstudiante);

            Console.WriteLine("Que curso deseas vincular?");
            var nombreCurso = Console.ReadLine();
            Console.WriteLine();
            var curso = cursos.FirstOrDefault(cur => cur.Name.Equals(nombreCurso, StringComparison.InvariantCultureIgnoreCase));
            if (curso == null)
            {
                Console.WriteLine("Este curso no existe");
                Console.WriteLine();
                return;
            }
            if (EstudianteYaInscripto(curso.Name, cursosEstudiante))
            {
                Console.WriteLine("El estudiante ya se encuentra inscrpito en este curso");
                Console.WriteLine();
                return;
            }

            var queryString = $"insert into estudianteCurso (idEstudiante,idCurso,fechaInscripcion) " +
                $"values ({estudiante.Id},{curso.Id},'{DateTime.Now}')";

            _repo.EjecutarQuery(queryString);
            Console.WriteLine($"Registro ingresado");
            Console.WriteLine();
        }
        private void DesinscribirAlumnoEscuela()
        {
            var estudiantes = MostrarYTraerTodosEstudiantes();
            Console.WriteLine("Que estudiante deseas desinscribir? Escribe el nombre o el dni");
            var nombreDniEstudiante = Console.ReadLine();
            var estudiante = estudiantes.FirstOrDefault(est => est.Name.Equals(nombreDniEstudiante, StringComparison.InvariantCultureIgnoreCase)
                                                             || est.Dni.ToString().Equals(nombreDniEstudiante, StringComparison.InvariantCultureIgnoreCase));
            if (estudiante == null)
            {
                Console.WriteLine("Este estudiante no existe");
                return;
            }
            if (estudiante.IdEscuela == null)
            {
                Console.WriteLine("Este estudiante no pertenece a ninguna escuela");
                return;
            }

            var queryString = $"update estudiantes set idEscuela = null where id = {estudiante.Id}";
            _repo.EjecutarQuery(queryString);
            var queryStringCursos = $"delete from estudianteCurso where idEstudiante = {estudiante.Id}";
            _repo.EjecutarQuery(queryStringCursos);
            Console.WriteLine($"Se desinscribio al alumno correctamente");
            Console.WriteLine();
        }
        private void DesinscribirAlumnoCurso()
        {
            var estudiantes = MostrarYTraerTodosEstudiantes();
            Console.WriteLine("Que estudiante deseas desinscribir? Escribe el nombre o el dni");
            var nombreDniEstudiante = Console.ReadLine();
            var estudiante = estudiantes.FirstOrDefault(est => est.Name.Equals(nombreDniEstudiante, StringComparison.InvariantCultureIgnoreCase)
                                                             || est.Dni.ToString().Equals(nombreDniEstudiante, StringComparison.InvariantCultureIgnoreCase));
            if (estudiante == null)
            {
                Console.WriteLine("Este estudiante no existe");
                return;
            }
            if (estudiante.IdEscuela == null)
            {
                Console.WriteLine("Este estudiante no pertenece a ninguna escuela");
                return;
            }

            var cursosEstudiante = ConsultarCursosEstudiante(estudiante.Id);
            if (cursosEstudiante.Count == 0)
            {
                Console.WriteLine("El estudiante no esta inscripto en ningun curso");
                return;
            }
            MostrarCursosEstudiante(cursosEstudiante);
            Console.WriteLine("De qué curso deseas desinscribir al alumno?");
            var nombreCurso = Console.ReadLine();
            Console.WriteLine();
            var curso = cursosEstudiante.FirstOrDefault(cur => cur.NombreCurso.Equals(nombreCurso, StringComparison.InvariantCultureIgnoreCase));
            if (curso == null)
            {
                Console.WriteLine("Este curso no existe");
                Console.WriteLine();
                return;
            }

            var queryString = $"delete from estudianteCurso where idEstudiante = {estudiante.Id} and idCurso = {curso.IdCurso}";
            _repo.EjecutarQuery(queryString);
            Console.WriteLine("Alumno desinscripto correctamente");
            Console.WriteLine();
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

        private void EliminarEstudiante()
        {
            var estudiante = TraerYMostrarEstudiantePorDni();
            if (estudiante == null) return;
            var queryString = $"delete from estudiantes where id = {estudiante.Id}";
            _repo.EjecutarQuery(queryString);
            Console.WriteLine($"Registro eliminado");
            Console.WriteLine();
        }

        private Estudiante TraerYMostrarEstudiantePorDni()
        {
            Console.WriteLine("Cual es el numero de dni del estudiante?");
            var dni = Console.ReadLine();

            var queryStringSelect = "select * from estudiantes where dni = @dni";
            var parametrosSelect = new List<SqlParameter>() { CrearParametro("@dni", dni), };
            var estudiante = _repo.DevolverDatoTabla(queryStringSelect, DevolverEstudiantes, parametrosSelect);
            if (estudiante == null)
                Console.WriteLine("El estudiante no existe");
            else
                estudiante.MostrarCompleto();

            Console.WriteLine();
            return estudiante;

        }

        private Estudiante UnificarCursos(List<Estudiante> estudiantes)
        {
            if (estudiantes.Count == 0) return null;
            var estudiante = estudiantes.First();
            estudiante.CursosEstudiantes = estudiantes.SelectMany(est => est.CursosEstudiantes).ToList();

            return estudiante;
        }
        private List<Escuela> TraerYMostrarTodasLasEscuelas()
        {
            var queryString = "Select * from escuelas order by name";
            var escuelas = _repo.DevolverDatosTabla(queryString, DevolverEscuelas);
            foreach (var escuela in escuelas)
            {
                Console.WriteLine(escuela);
            }
            Console.WriteLine();
            return escuelas;
        }

        private List<Curso> TraerYMostrarTodosLosCursosPorEscuela(Estudiante estudiante)
        {
            if (estudiante.IdEscuela == null)
            {
                Console.WriteLine("El estudiante no pertenece a ninguna escuela");
                return null;
            }
            else
            {
                var queryString = $"Select * from cursos where idEscuela = @idEscuela and archivado = 0 order by name";
                var parametros = new List<SqlParameter>() { CrearParametro("@idEscuela", estudiante.IdEscuela.ToString(), true) };
                var cursos = _repo.DevolverDatosTabla(queryString, DevolverCursos, parametros);
                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso);
                }
                Console.WriteLine();
                return cursos;
            }
            
        }
        private void MostrarCursosEstudiante (List<CursoEstudiante> cursosEstudiante)
        {
            Console.WriteLine("Cursos inscrptos del estudiante:");
          
            foreach (var ce in cursosEstudiante)
            {
                Console.WriteLine(ce.NombreCurso);
            }
            Console.WriteLine();
            
            
        }

        private List<CursoEstudiante> ConsultarCursosEstudiante(int idEstudiante)
        {
            var queryString = "Select c.name as nameCurso, c.id as idCurso from estudianteCurso ec " +
                "join cursos c on ec.idCurso = c.id " +
                $"where ec.idEstudiante = {idEstudiante}";
            var cursosEstudiante = _repo.DevolverDatosTabla(queryString, DevolverEstudianteCurso);
            return cursosEstudiante;
        }
        private bool EstudianteYaInscripto(string curso,List<CursoEstudiante> cursosInscriptos)
        {
            var inscripto = false;
            if (cursosInscriptos != null)
            {
                foreach (var c in cursosInscriptos)
                {
                    if (c.NombreCurso == curso) inscripto = true;
                }
            }
            
            return inscripto;    
        }
    }
}
