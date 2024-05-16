using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prueba
{
    internal class FamiliaContext : DbContext
    {
        public FamiliaContext() : base("Data Source=.\\SQLEXPRESS;Initial Catalog=Familia;Integrated Security=true;") 
        {
            Database.SetInitializer<FamiliaContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Hijo> Hijos { get; set; }
        public DbSet<Dni> Dnis { get; set; }
        public DbSet<Cumpleaños> Cumpleaños { get; set; }
        public DbSet<Comida> Comidas { get; set; }
        public DbSet<HijoComida> HijosComidas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HijoConfiguration());
            modelBuilder.Configurations.Add(new DniConfiguration());
            modelBuilder.Configurations.Add(new CumpleañosConfiguration());
            modelBuilder.Configurations.Add(new ComidaConfiguration());
            modelBuilder.Configurations.Add(new HijoComidaConfiguration());
        }
    }
}
