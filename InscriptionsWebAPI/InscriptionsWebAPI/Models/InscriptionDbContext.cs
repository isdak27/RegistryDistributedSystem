using Microsoft.EntityFrameworkCore;
using System;

namespace InscriptionsWebAPI.Models
{
    public partial class InscriptionDbContext : DbContext
    {
        public InscriptionDbContext(DbContextOptions<InscriptionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Inscription> Inscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configura el proveedor de base de datos para SQL Server
                optionsBuilder.UseSqlServer("Server=register-server.database.windows.net;Database=Registro;User Id=adminregister;Password=#admin123register;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inscription>(entity =>
            {
                entity.ToTable("inscripcion");

                entity.HasKey(e => e.code);

                entity.Property(e => e.code).HasColumnName("id_inscripcion").HasColumnType("int");

                entity.Property(e => e.StudentCode).HasColumnName("codigo_estudiante").HasColumnType("int");

                entity.Property(e => e.SubjectCode).HasColumnName("codigo_materia").HasColumnType("int");

                entity.Property(e => e.InscriptionDate).HasColumnName("fecha_inscripcion").HasColumnType("datetime2");

                entity.Property(e => e.Status).HasColumnName("estado").HasColumnType("varchar(50)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
