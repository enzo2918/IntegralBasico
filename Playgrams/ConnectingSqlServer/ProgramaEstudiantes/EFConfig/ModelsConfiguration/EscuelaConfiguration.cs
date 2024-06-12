using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.ModelsConfiguration
{
    internal class EscuelaConfiguration : EntityTypeConfiguration<Escuela>
    {
        public EscuelaConfiguration() 
        {
            ToTable("escuelas");

            HasKey(pk => pk.Id);

            Property(pi => pi.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(pn => pn.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();
        }

    }
}
