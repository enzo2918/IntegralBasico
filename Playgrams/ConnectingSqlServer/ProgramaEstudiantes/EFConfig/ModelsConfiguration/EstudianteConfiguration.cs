using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.EFConfig.ModelsConfiguration
{
    internal class EstudianteConfiguration : EntityTypeConfiguration<Estudiante>
    {
        public EstudianteConfiguration()
        {
            ToTable("estudiantes");

            HasKey(pk => pk.Id);

            Property(pi => pi.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(pn => pn.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            Property(pn => pn.Dni)
                .HasColumnName("dni")
                .HasMaxLength(100)
                .IsRequired();

            Property(pn => pn.Telefono)
                .HasColumnName("telefono")
                .HasMaxLength(100);

            HasOptional(est => est.Escuela)
                .WithMany(esc => esc.Estudiantes)
                .HasForeignKey(fk => fk.IdEscuela);

            HasMany(est => est.EstudiantesCursos)
                .WithRequired(ec => ec.Estudiante)
                .HasForeignKey(ec => ec.IdEstudiante);

        }
    }
}
