using DBEgzaminas_StudentuInfoSistema.Database.Entities;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DBEgzaminas_StudentuInfoSistema.Database.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StudentsContext _context;
        private readonly DbSet<Department> _departments;

        public DepartmentRepository(StudentsContext context)
        {
            _context = context;
            _departments = _context.Set<Department>();
        }

        public Department GetByCode(string code)
        {
            return _departments.Find(code);
        }

        public IEnumerable<Department> GetAll()
        {
            return _departments;
        }

        public string Create(Department department)
        {
            _context.Add(department);
            _context.SaveChanges();

            return department.DepartmentCode;
        }

        public void Update(Department department)
        {
            _departments.Update(department);
            _context.SaveChanges();
        }

        public void Delete(string code)
        {
            var department = _departments.Find(code);
            if (department != null)
            {
                _departments.Remove(department);
                _context.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

    public class LectureRepository : ILectureRepository
    {
        private readonly StudentsContext _context;
        private readonly DbSet<Lecture> _lectures;

        public LectureRepository(StudentsContext context)
        {
            _context = context;
            _lectures = _context.Set<Lecture>();
        }

        public Lecture GetById(int id)
        {
            return _lectures.Find(id);
        }

        public IEnumerable<Lecture> GetAll()
        {
            return _lectures;
        }

        public int Create(Lecture lecture)
        {
            _context.Add(lecture);
            _context.SaveChanges();

            return lecture.LectureId;
        }

        public void Update(Lecture lecture)
        {
            _lectures.Update(lecture);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var lecture = _lectures.Find(id);
            if (lecture != null)
            {
                _lectures.Remove(lecture);
                _context.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

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
