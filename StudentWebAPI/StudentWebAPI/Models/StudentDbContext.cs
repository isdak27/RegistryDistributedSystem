using Microsoft.EntityFrameworkCore;

namespace StudentWebAPI.Models
{
    public partial class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

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
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("estudiante");

                entity.HasKey(e => e.code);

                entity.Property(e => e.code).HasColumnName("codigo").HasColumnType("bigint");

                entity.Property(e => e.name).HasColumnName("nombre").HasColumnType("nvarchar(50)");

                entity.Property(e => e.lastName).HasColumnName("apellido").HasColumnType("nvarchar(50)");

                entity.Property(e => e.documentType).HasColumnName("tipo_documento").HasColumnType("nchar(10)");

                entity.Property(e => e.documentNumber).HasColumnName("numero_documento").HasColumnType("nvarchar(50)");

                entity.Property(e => e.gender).HasColumnName("genero").HasColumnType("nchar(10)");

                entity.Property(e => e.status).HasColumnName("estado").HasColumnType("varchar(MAX)");

                entity.Property(e => e.imageRef).HasColumnName("imagen_ref").HasColumnType("nvarchar(MAX)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
