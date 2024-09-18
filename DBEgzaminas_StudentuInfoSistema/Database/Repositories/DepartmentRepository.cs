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

        public Department GetById(string code)
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

        public void Delete(int code)
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

    public class LectureRepository
    {
    }

    public class StudentRepository
    {
    }
}
