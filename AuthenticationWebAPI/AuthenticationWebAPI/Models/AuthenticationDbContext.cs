using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AuthenticationWebAPI.Models
{
    public partial class AuthenticationDbContext : DbContext
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=register-server.database.windows.net;Database=Registro;User Id=adminregister;Password=#admin123register;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasKey(e => e.id);

                entity.Property(e => e.id).HasColumnName("id_usuario").HasColumnType("int");

                entity.Property(e => e.name).HasColumnName("nombre_usuario").HasColumnType("nvarchar(100)");

                entity.Property(e => e.email).HasColumnName("correo").HasColumnType("nvarchar(100)");

                entity.Property(e => e.status).HasColumnName("estado").HasColumnType("bit");

                entity.Property(e => e.userName).HasColumnName("usuario_acceso").HasColumnType("nvarchar(100)");

                entity.Property(e => e.password).HasColumnName("contraseña").HasColumnType("nvarchar(100)");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}
