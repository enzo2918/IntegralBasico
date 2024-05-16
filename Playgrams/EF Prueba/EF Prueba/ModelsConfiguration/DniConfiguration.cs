using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prueba
{
    internal class DniConfiguration : EntityTypeConfiguration<Dni>
    {
        public DniConfiguration() 
        {
            ToTable("Dni");

            // Configuración de la clave primaria
            HasKey(pk => pk.Id);

            // Configuración de las propiedades
            Property(pi => pi.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Indica que es autoincremental

            Property(pn => pn.NumeroDni)
                .HasColumnName("NumeroDni")
                .HasMaxLength(10)
                .IsRequired();

            //Property(pi => pi._IdHijo)
            //    .HasColumnName("IdHijo");

            HasRequired(d => d.Hijo)
                .WithOptional(h => h.Dni)
                .Map(m => m.MapKey("IdHijo"));
        }
    }
}
