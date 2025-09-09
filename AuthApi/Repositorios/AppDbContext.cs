using AuthApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AuthApi.Repositorios
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

    public DbSet<CategoriaJA> CategoriasJA { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Email único
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Relación 1 Rol -> N Usuarios
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);

            // Opcional: restricciones para CategoriaEL
            modelBuilder.Entity<CategoriaJA>()
                .Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<CategoriaJA>()
                .Property(c => c.Descripcion)
                .HasMaxLength(255);
        }
    }
}