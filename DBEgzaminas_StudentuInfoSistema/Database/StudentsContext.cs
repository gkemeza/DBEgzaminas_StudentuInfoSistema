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
                entity.Property(a => a.FirstName).HasColumnType("nvarchar(50)");
                entity.Property(a => a.LastName).HasColumnType("nvarchar(50)");

                entity.HasMany(l => l.Lectures)
                .WithMany(d => d.Students);

                entity.HasOne(d => d.Departament)
                .WithMany(s => s.Students)
                .HasForeignKey(d => d.DepartamentCode);
                //.OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Departament>(departament =>
            {

            });
        }
    }
}
