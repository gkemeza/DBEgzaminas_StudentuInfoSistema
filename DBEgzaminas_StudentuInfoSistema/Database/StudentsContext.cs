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
            // change to StudentNumber?
            modelBuilder.Entity<Student>()
                .HasKey(a => a.StudentId);

            modelBuilder.Entity<Student>()
                .Property(a => a.FirstName).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Student>()
                .Property(a => a.LastName).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Student>()
                .Property(a => a.StudentNumber).HasColumnType("int");

            modelBuilder.Entity<Student>()
                .HasMany(l => l.Lectures);

            modelBuilder.Entity<Student>()
                .HasOne(d => d.Departament)
                .WithMany(s => s.Students)
                .HasForeignKey(d => d.DepartamentId);
            //.OnDelete(DeleteBehavior.NoAction);
        }
    }
}
