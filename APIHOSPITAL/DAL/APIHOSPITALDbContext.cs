using APIHOSPITAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APIHOSPITAL.DAL
{
    public class APIHOSPITALDbContext : DbContext
    {
        public APIHOSPITALDbContext(DbContextOptions options) : base(options)
        {
        }

        // Define los DbSet para cada una de las entidades del modelo
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        // Override del método OnModelCreating para configurar las entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapea las entidades a sus respectivas tablas en la base de datos
            modelBuilder.Entity<Medico>().ToTable("Medico");
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<Reserva>().ToTable("Reserva");
        }
    }
}


