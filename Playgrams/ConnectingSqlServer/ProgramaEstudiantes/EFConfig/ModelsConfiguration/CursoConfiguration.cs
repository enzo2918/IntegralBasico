using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.EFConfig.ModelsConfiguration
{
    internal class CursoConfiguration : EntityTypeConfiguration<Curso>
    {
        public CursoConfiguration() 
        {
            ToTable("cursos");

            HasKey(pk => pk.Id);

            Property(pi => pi.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(pn => pn.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            Property(pn => pn.Archivado)
                .HasColumnName("archivado")
                .IsRequired();

            HasRequired(cur => cur.Escuela)
                .WithMany(esc => esc.Cursos)
                .HasForeignKey(fk => fk.IdEscuela);

            HasMany(cur => cur.EstudiantesCursos)
                .WithRequired(ec => ec.Curso)
                .HasForeignKey(ec => ec.IdCurso);
        }
    }
}
