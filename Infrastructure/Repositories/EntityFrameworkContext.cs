using Microsoft.EntityFrameworkCore;
using NumeroAsignadoProject.Domain.Entities;

namespace NumeroAsignadoProject.Infrastructure.Repositories
{
    public class EntityFrameworkContext : DbContext
    {
        public DbSet<NumeroAsignado> NumerosAsignados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public EntityFrameworkContext(DbContextOptions<EntityFrameworkContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la tabla NumerosAsignados
            modelBuilder.Entity<NumeroAsignado>()
                .HasKey(n => n.Id);
            modelBuilder.Entity<NumeroAsignado>()
                .Property(n => n.Numero)
                .IsRequired();

            // Configuración de la tabla Clientes
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nombre)
                .IsRequired();
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Email)
                .IsRequired();
            modelBuilder.Entity<Cliente>()
                .Property(c => c.ApiKey)
                .IsRequired();

            // Configuración de la tabla Productos
            modelBuilder.Entity<Producto>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Producto>()
                .Property(p => p.Nombre)
                .IsRequired();
            modelBuilder.Entity<Producto>()
                .Property(p => p.Descripcion)
                .IsRequired();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
