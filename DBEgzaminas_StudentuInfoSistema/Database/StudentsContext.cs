using DBEgzaminas_StudentuInfoSistema.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBEgzaminas_StudentuInfoSistema.Database
{
    public class StudentsContext : DbContext
    {
        public StudentsContext() : base() { }

        public StudentsContext(DbContextOptions options) : base(options) { }

        DbSet<Student> Students { get; set; }
        DbSet<Department> Departments { get; set; }
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
                .WithMany(d => d.Students)
                .UsingEntity(j => j.HasData(CsvHelperService.GetLecturesStudents()));

                entity.HasOne(d => d.Department)
                .WithMany(s => s.Students)
                .HasForeignKey(d => d.DepartmentCode);

                entity.HasData(CsvHelperService.GetStudents());
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(a => a.DepartmentCode);
                entity.Property(a => a.DepartmentCode).HasMaxLength(6);
                entity.Property(a => a.DepartmentName).HasColumnType("nvarchar(100)").IsRequired();

                entity.HasMany(l => l.Lectures)
                      .WithMany(d => d.Departments)
                      .UsingEntity(j => j.HasData(CsvHelperService.GetDepartmentsLectures()));

                entity.HasData(CsvHelperService.GetDepartments());
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasKey(a => a.LectureId);
                entity.HasIndex(a => a.LectureName).IsUnique();
                entity.Property(a => a.StartTime).HasColumnType("time(0)").IsRequired();
                entity.Property(a => a.EndTime).HasColumnType("time(0)").IsRequired();
                entity.Property(a => a.Weekday).HasConversion<string>();

                entity.HasData(CsvHelperService.GetLectures());
            });
        }
    }
}
