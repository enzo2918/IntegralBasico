using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prueba
{
    internal class CumpleañosConfiguration : EntityTypeConfiguration<Cumpleaños>
    {
        public CumpleañosConfiguration()
        {
            ToTable("Cumpleaños");

            // Configuración de la clave primaria
            HasKey(pk => pk.Id);

            // Configuración de las propiedades
            Property(pi => pi.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Indica que es autoincremental

            Property(pf => pf.FechaCumpleaños)
                .HasColumnName("FechaCumpleaños")
                .IsRequired();
        }
    }
}
