using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prueba
{
    internal class ComidaConfiguration : EntityTypeConfiguration<Comida>
    {
        public ComidaConfiguration()
        {
            ToTable("Comida");

            // Configuración de la clave primaria
            HasKey(pk => pk.Id);


            // Configuración de las propiedades
            Property(pi => pi.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Indica que es autoincremental

            Property(pn => pn.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            HasMany(h => h.HijosComidas)
                .WithRequired(hc => hc.Comida)
                .HasForeignKey(hc => hc.IdComida);


        }
    }
}
