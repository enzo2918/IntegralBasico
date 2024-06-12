using ProgramaEstudiantes.Exceptions;
using ProgramaEstudiantes.Repositorios;
using ProgramaEstudiantes.Repositorios.ConsultasCrudas;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    public class Inicio
    {
        private IEstudianteRepositorio _repoEstudiantes;
        private ICursoRepositorio _repoCursos;
        private IEscuelaRepositorio _repoEscuelas;
        private IErrorCRRepositorio _repoError;
        private IPedir _pedir;
        private IMostrar _mostrar;
        private IObtener _obtener;

        public Inicio(IEstudianteRepositorio estudianteRepositorio, ICursoRepositorio cursoRepositorio, 
            IEscuelaRepositorio escuelaRepositorio, IErrorCRRepositorio errorRepositorio, IPedir pedir, IMostrar mostrar, IObtener obtener)
        {
            _repoEstudiantes = estudianteRepositorio;
            _repoCursos = cursoRepositorio;
            _repoEscuelas = escuelaRepositorio;
            _repoError = errorRepositorio;
            _pedir = pedir;
            _mostrar = mostrar;
            _obtener = obtener;
        }

        public void IniciarPrograma()
        {

            int accionARealizar;

            do
            {
                var menuOpciones = "Seleccione la opcion que desee realizar:" + Environment.NewLine +
                    "1. Consultar todos los estudiantes" + Environment.NewLine +
                    "2. Consultar un estudiante en detalle" + Environment.NewLine +
                    "3. Agregar un estudiante" + Environment.NewLine +
                    "4. Modificar un estudiante" + Environment.NewLine +
                    "5. Eliminar un estudiante" + Environment.NewLine +
                    "6. Inscribir estudiante a una escuela" + Environment.NewLine +
                    "7. Inscribir estudiante a un curso" + Environment.NewLine +
                    "8. Desinscribir estudiante de una escuela" + Environment.NewLine +
                    "9. Desinscribir estudiante de un curso" + Environment.NewLine +
                    "10. Largar Error" + Environment.NewLine +
                    "11. Salir" + Environment.NewLine;

                accionARealizar = _pedir.Entero(menuOpciones, (1, 11));
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
                        CrearEstudiante();
                        break;
                    case 4:
                        ModificarEstudiante();
                        break;
                    case 5:
                        EliminarEstudiante();
                        break;
                    case 6:
                        InscribirAlumnoEscuela();
                        break;
                    case 7:
                        InscribirAlumnoCursos();
                        break;
                    case 8:
                        DesinscribirAlumnoEscuela();
                        break;
                    case 9:
                        DesinscribirAlumnoCurso();
                        break;
                    case 10:
                        LargarError();
                        break;
                }

            } while (accionARealizar != 11);

        }

        #region opciones menus

        private void MostrarTodosEstudiantes()
        {
            _obtener.EstudiantesYMostrarTodos(); 
        }

        private void ConsultarEstudianteEnDetalle()
        {
            _obtener.EstudiantesYMostrarTodos();
            var nombreDniEstudiante = _pedir.Cadena("Que estudiante deseas ver en detalle? Escribe el nombre o el dni");            
            var estudiante = _repoEstudiantes.ObtenerEstudianteConRelaciones(nombreDniEstudiante);
            if (estudiante == null)
            {
                throw new EstudianteInexistenteException("Este estudiante no existe", nombreDniEstudiante);
            }

            _mostrar.EstudianteYRelaciones(estudiante);
        }

        private void CrearEstudiante()
        {            
            var nombre = _pedir.Cadena("Cual es el nombre del estudiante?");            
            var dni = _pedir.Cadena("Cual es su numero de DNI?");
            var telefono = _pedir.Cadena("Cual es su numero de telefono?");
            _repoEstudiantes.InsertarEstudiante(nombre,dni,telefono);
            Console.WriteLine();
        }

        private void ModificarEstudiante()
        {
            var estudiante = _obtener.EstudianteDesdeElUsuario();
            _mostrar.EstudianteCompleto(estudiante);

            var columnaAModificar = _pedir.Entero("Que categoria desea modificar:\n1. Nombre\n2. DNI\n3. Telefono", (1, 3));
            var nuevoValorColumna = _pedir.Cadena("Cual es el nuevo valor?");

            switch (columnaAModificar)
            {
                case 1:
                    estudiante.Name = nuevoValorColumna;
                    break;
                case 2:
                    estudiante.Dni = nuevoValorColumna;
                    break;
                case 3:
                    estudiante.Telefono = nuevoValorColumna;
                    break;
            }

            _repoEstudiantes.ActualizarEstudiante(estudiante);
            Console.WriteLine($"Registro modificado");
            Console.WriteLine();


        }

        private void EliminarEstudiante()
        {
            var estudiante = _obtener.EstudianteDesdeElUsuario(); 
            _mostrar.EstudianteCompleto(estudiante);
            _repoEstudiantes.DesvincularAlumnoDeTodosLosCursos(estudiante.Id);
            _repoEstudiantes.EliminarEstudiante(estudiante.Id);
            Console.WriteLine($"Registro eliminado");
            Console.WriteLine();
        }

        private void InscribirAlumnoEscuela()
        {
            var estudiante = _obtener.EstudianteDesdeElUsuario();

            if (estudiante.IdEscuela != null)
            {
                Console.WriteLine("Este estudiante ya esta inscripto en otra escuela");
                return;

            }
            Console.WriteLine();

            var escuelas = _obtener.EscuelasYMostrar();
            var nombreEscuela = _pedir.Cadena("A que escuela lo quieres vincular?");
            var escuela = escuelas.FirstOrDefault(esc => esc.Name.Equals(nombreEscuela, StringComparison.InvariantCultureIgnoreCase));
            if (escuela == null)
            {
                Console.WriteLine("Esta escuela no existe");
                return;
            }
            Console.WriteLine();

            _repoEstudiantes.VincularAlumnoEscuela(escuela.Id,estudiante.Id);
            Console.WriteLine($"Alumno inscripto correctamente");
            Console.WriteLine();
        }

        private void InscribirAlumnoCursos()
        {
            var estudiante = _obtener.EstudianteDesdeElUsuario();

            var cursos = _obtener.CursosPorEscuelaYMostrar(estudiante);
            if (cursos == null) return;
            var cursosEstudiante = _repoCursos.ObtenerCursosEstudiante(estudiante.Id);
            _mostrar.CursosEstudiante(cursosEstudiante);
            
            var nombreCurso = _pedir.Cadena("En qué curso deseas inscribir al estudiante?");
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
            
            _repoEstudiantes.VincularAlumnoCursos(estudiante.Id,curso.Id);
            Console.WriteLine($"Registro ingresado");
            Console.WriteLine();
        }

        private void DesinscribirAlumnoEscuela()
        {
            var estudiante = _obtener.EstudianteDesdeElUsuario();

            if (estudiante.IdEscuela == null)
            {
                Console.WriteLine("Este estudiante no pertenece a ninguna escuela");
                return;
            }
            
            _repoEstudiantes.DesvincularAlumnoDeTodosLosCursos(estudiante.Id);
            _repoEstudiantes.DesvincularAlumnoEscuela(estudiante.Id);

            Console.WriteLine($"Se desinscribio al alumno correctamente");
            Console.WriteLine();
        }

        private void DesinscribirAlumnoCurso()
        {
            var estudiante = _obtener.EstudianteDesdeElUsuario();

            if (estudiante.IdEscuela == null)
            {
                Console.WriteLine("Este estudiante no pertenece a ninguna escuela");
                return;
            }

            var cursosEstudiante = _repoCursos.ObtenerCursosEstudiante(estudiante.Id); ;
            if (cursosEstudiante.Count == 0)
            {
                Console.WriteLine("El estudiante no esta inscripto en ningun curso");
                return;
            }
            _mostrar.CursosEstudiante(cursosEstudiante);
            Console.WriteLine("De qué curso deseas desinscribir al alumno?");
            var nombreCurso = _pedir.Cadena("De qué curso deseas desinscribir al alumno?");
            Console.WriteLine();
            var cursoEstudiante = cursosEstudiante.FirstOrDefault(cur => cur.Curso.Name.Equals(nombreCurso, StringComparison.InvariantCultureIgnoreCase));
            if (cursoEstudiante == null)
            {
                Console.WriteLine("Este curso no existe");
                Console.WriteLine();
                return;
            }

            _repoEstudiantes.DesvincularAlumnoCurso(estudiante.Id,cursoEstudiante.IdCurso);
            Console.WriteLine("Alumno desinscripto correctamente");
            Console.WriteLine();
        }
        private void LargarError()
        {
            _repoError.Error();
        }

        #endregion                                             

        private bool EstudianteYaInscripto(string curso,List<EstudianteCurso> cursosInscriptos)
        {
            var inscripto = false;
            if (cursosInscriptos != null)
            {
                foreach (var c in cursosInscriptos)
                {
                    if (c.Curso.Name == curso) inscripto = true;
                }
            }
            
            return inscripto;    
        }
    }
}
