using Microsoft.EntityFrameworkCore;

namespace SubjectWebAPI.Models
{
    public partial class SubjectDbContext : DbContext
    {
        public SubjectDbContext(DbContextOptions<SubjectDbContext> options)
           : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=register-server.database.windows.net;Database=Registro;User Id=adminregister;Password=#admin123register;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("materia");

                entity.HasKey(e => e.code);

                entity.Property(e => e.code).HasColumnName("codigo").HasColumnType("nvarchar(50)");

                entity.Property(e => e.name).HasColumnName("nombre").HasColumnType("nvarchar(50)");

                entity.Property(e => e.group).HasColumnName("grupo").HasColumnType("int");

                entity.Property(e => e.quotas).HasColumnName("cupos").HasColumnType("int");

                entity.Property(e => e.actualStatus).HasColumnName("estado").HasColumnType("nvarchar(50)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

