using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prueba
{
    internal class HijoConfiguration : EntityTypeConfiguration<Hijo>
    {
        public HijoConfiguration()
        {

            ToTable("Hijo");

            // Configuración de la clave primaria
            HasKey(pk => pk.Id);

            // Configuración de las propiedades
            Property(p => p.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Indica que es autoincremental

            Property(pn => pn.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            HasOptional(h => h.Cumpleaños)
                .WithMany(c => c.Hijos)
                .HasForeignKey(fk => fk.IdCumpleaños);

            //HasMany(h => h.Comidas)
            //    .WithMany(c => c.Hijos)
            //    .Map (m =>
            //        {   
            //            m.ToTable("HijoComida"); // Nombre de la tabla de la relación muchos a muchos
            //            m.MapLeftKey("IdHijo"); // Nombre de la clave foránea a la tabla Estudiante
            //            m.MapRightKey("IdComida"); // Nombre de la clave foránea a la tabla Curso
            //        });

            HasMany(h => h.HijosComidas)
                .WithRequired(hc => hc.Hijo)
                .HasForeignKey(hc => hc.IdHijo);


        }
    }
}
