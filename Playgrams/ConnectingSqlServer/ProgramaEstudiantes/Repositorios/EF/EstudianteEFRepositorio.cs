using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.Repositorios.EF
{
    public class EstudianteEFRepositorio : IEstudianteRepositorio
    {
        public List<Estudiante> ObtenerEstudiantes()
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var estudiantes = BDEstudiantes.Estudiantes.ToList();
                return estudiantes;
            }

        }
        public Estudiante ObtenerEstudianteConRelaciones(string nombreDniEstudiante)
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var estudiante = BDEstudiantes.Estudiantes
                                              .Include(est => est.Escuela)
                                              .Include(e => e.EstudiantesCursos.Select(ec => ec.Curso))
                                              .FirstOrDefault(e => e.Name == nombreDniEstudiante || e.Dni == nombreDniEstudiante);
                if (estudiante != null) estudiante.EstudiantesCursos = estudiante.EstudiantesCursos.Where(ec => !ec.Curso.Archivado).ToList();
                return estudiante;
            }
        }

        public void InsertarEstudiante(string nombre, string dni, string telefono)
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var nuevoEstudiante = new Estudiante()
                {
                    Name = nombre,
                    Dni = dni,
                    Telefono = telefono
                };

                BDEstudiantes.Estudiantes.Add(nuevoEstudiante);
                BDEstudiantes.SaveChanges();
            }            
        }
        public void ActualizarEstudiante(Estudiante estudiante)
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var estudianteBD = BDEstudiantes.Estudiantes.First(e => e.Id == estudiante.Id);

                estudianteBD.Name = estudiante.Name;
                estudianteBD.Dni = estudiante.Dni;
                estudianteBD.Telefono = estudiante.Telefono;

                BDEstudiantes.SaveChanges();
            }                
        }
        public void EliminarEstudiante(int estudianteId)
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var estudiante = BDEstudiantes.Estudiantes.First(e => e.Id == estudianteId);
                BDEstudiantes.Estudiantes.Remove(estudiante);
                BDEstudiantes.SaveChanges();
            }                
        }

        public void VincularAlumnoEscuela(int escuelaId, int estudianteId)
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var estudiante = BDEstudiantes.Estudiantes.First(e => e.Id == estudianteId);
                estudiante.IdEscuela = escuelaId;
                BDEstudiantes.SaveChanges();
            }
        }

        public void VincularAlumnoCursos(int estudianteId, int cursoId)
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var estudianteCurso = new EstudianteCurso()
                {
                    IdEstudiante = estudianteId,
                    IdCurso = cursoId,
                    FechaInscripcion = DateTime.Now
                }; 
                BDEstudiantes.EstudiantesCursos.Add(estudianteCurso);
                BDEstudiantes.SaveChanges();
            }
        }
        public void DesvincularAlumnoEscuela(int estudianteId)
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var estudiante = BDEstudiantes.Estudiantes.First(e => e.Id == estudianteId);
                estudiante.IdEscuela = null;
                BDEstudiantes.SaveChanges();
            }
        }
        public void DesvincularAlumnoDeTodosLosCursos(int estudianteId)
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var estudianteCursos = BDEstudiantes.EstudiantesCursos.Where(ec => ec.IdEstudiante == estudianteId).ToList();
                BDEstudiantes.EstudiantesCursos.RemoveRange(estudianteCursos);
                BDEstudiantes.SaveChanges();
            }
        }

        public void DesvincularAlumnoCurso(int estudianteId, int cursoId)
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var estudianteCurso = BDEstudiantes.EstudiantesCursos.First(ec => ec.IdEstudiante == estudianteId && ec.IdCurso == cursoId);
                BDEstudiantes.EstudiantesCursos.Remove(estudianteCurso);
                BDEstudiantes.SaveChanges();
            }
        }




        
    }

}
