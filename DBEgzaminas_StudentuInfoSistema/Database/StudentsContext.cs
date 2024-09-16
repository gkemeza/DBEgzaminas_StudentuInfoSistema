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

        }
    }
}
