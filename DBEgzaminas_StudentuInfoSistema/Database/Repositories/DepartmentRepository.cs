using DBEgzaminas_StudentuInfoSistema.Database.Entities;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DBEgzaminas_StudentuInfoSistema.Database.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly SystemContext _context;
        private readonly DbSet<Department> _departments;

        public DepartmentRepository(SystemContext context)
        {
            _context = context;
            _departments = _context.Set<Department>();
        }

        public Department? GetByCode(string code)
        {
            return _departments
                .Include(d => d.Students)
                .Include(d => d.Lectures)
                .FirstOrDefault(d => d.DepartmentCode == code);
        }

        public IEnumerable<Department> GetAll()
        {
            return _departments;
        }

        public string Create(Department department)
        {
            _departments.Add(department);
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
}
