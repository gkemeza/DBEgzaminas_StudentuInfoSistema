using DBEgzaminas_StudentuInfoSistema.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBEgzaminas_StudentuInfoSistema.Database
{
    public class StudentsContext : DbContext
    {
        public StudentsContext() : base() { }

        public StudentsContext(DbContextOptions options) : base(options) { }

        DbSet<Student> Students { get; set; }
        DbSet<Departament> Departaments { get; set; }
        DbSet<Lecture> Lectures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB; Database=Egzaminas_StudentInfoSystem; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(a => a.StudentNumber);
                entity.Property(a => a.StudentNumber).HasPrecision(5); // gal nereik HasPrecision()?
                entity.Property(a => a.FirstName).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(a => a.LastName).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(a => a.Email).IsRequired();

                entity.HasMany(l => l.Lectures)
                .WithMany(d => d.Students);

                entity.HasOne(d => d.Departament)
                .WithMany(s => s.Students)
                .HasForeignKey(d => d.DepartamentCode);
                //.IsRequired();
                //.OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Departament>(entity =>
            {
                entity.HasKey(a => a.DepartamentCode);
                entity.Property(a => a.DepartamentCode).HasMaxLength(6);
                entity.Property(a => a.DepartamentName).HasColumnType("nvarchar(100)").IsRequired();

                entity.HasMany(l => l.Lectures)
                      .WithMany(d => d.Departaments);
            });
        }
    }
}
