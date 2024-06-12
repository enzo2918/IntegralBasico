using ProgramaEstudiantes.EFConfig.ModelsConfiguration;
using ProgramaEstudiantes.ModelsConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace ProgramaEstudiantes
{
    internal class EstudiantesContext : DbContext
    {
        public EstudiantesContext() : base("Data Source=.\\SQLEXPRESS;Initial Catalog=sistema_estudiantes;Integrated Security=true;")
        {
            Database.SetInitializer<EstudiantesContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EscuelaConfiguration());
            modelBuilder.Configurations.Add(new EstudianteConfiguration());
            modelBuilder.Configurations.Add(new CursoConfiguration());
            modelBuilder.Configurations.Add(new EstudianteCursoConfiguration());

        }
    }
}
