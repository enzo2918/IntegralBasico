using ProgramaEstudiantes.Exceptions;
using ProgramaEstudiantes.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    public class Obtener : IObtener
    {
        private IPedir _pedir;
        private IMostrar _mostrar;
        private IEstudianteRepositorio _repoEstudiantes;
        private IEscuelaRepositorio _repoEscuela;
        private ICursoRepositorio _repoCurso;

        public Obtener(IPedir pedir, IMostrar mostrar, IEstudianteRepositorio repoEstudiantes, IEscuelaRepositorio repoEscuela, ICursoRepositorio repoCurso)
        {
            _pedir = pedir;
            _mostrar = mostrar;
            _repoEstudiantes = repoEstudiantes;
            _repoEscuela = repoEscuela;
            _repoCurso = repoCurso;
        }
        public List<Estudiante> EstudiantesYMostrarTodos()
        {
            var estudiantes = _repoEstudiantes.ObtenerEstudiantes();
            foreach (var estudiante in estudiantes)
            {
                _mostrar.EstudianteSimplificado(estudiante);
            }
            Console.WriteLine();
            return estudiantes;
        }
        public Estudiante EstudianteDesdeElUsuario()
        {
            var estudiantes = EstudiantesYMostrarTodos();
            var nombreDniEstudiante = _pedir.Cadena("Que estudiante deseas inscribir? Escribe el nombre o el dni");
            var estudiante = estudiantes.FirstOrDefault(est => est.Name.Equals(nombreDniEstudiante, StringComparison.InvariantCultureIgnoreCase)
                                                             || est.Dni.ToString().Equals(nombreDniEstudiante, StringComparison.InvariantCultureIgnoreCase));
            if (estudiante == null)
            {
                throw new EstudianteInexistenteException("Este estudiante no existe", nombreDniEstudiante);
            }

            Console.WriteLine();
            return estudiante;
        }
        public List<Escuela> EscuelasYMostrar()
        {
            var escuelas = _repoEscuela.ObtenerEscuelas();
            foreach (var escuela in escuelas)
            {
                _mostrar.Escuela(escuela);
            }
            Console.WriteLine();
            return escuelas;
        }
        public List<Curso> CursosPorEscuelaYMostrar(Estudiante estudiante)
        {
            if (!estudiante.IdEscuela.HasValue)
            {
                Console.WriteLine("El estudiante no pertenece a ninguna escuela");
                return null;
            }
            else
            {
                var cursos = _repoCurso.ObtenerCursosPorEscuela(estudiante.IdEscuela.Value);
                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso);
                }
                Console.WriteLine();
                return cursos;
            }
        }
    }
 }
