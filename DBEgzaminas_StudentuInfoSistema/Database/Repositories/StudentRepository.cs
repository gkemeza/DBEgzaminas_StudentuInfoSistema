using DBEgzaminas_StudentuInfoSistema.Database.Entities;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DBEgzaminas_StudentuInfoSistema.Database.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsContext _context;
        private readonly DbSet<Student> _students;

        public StudentRepository(StudentsContext context)
        {
            _context = context;
            _students = _context.Set<Student>();
        }

        public Student GetById(int id)
        {
            return _students.Find(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public int Create(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();

            return student.StudentNumber;
        }

        public void Update(Student student)
        {
            _students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _students.Find(id);
            if (student != null)
            {
                _students.Remove(student);
                _context.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
