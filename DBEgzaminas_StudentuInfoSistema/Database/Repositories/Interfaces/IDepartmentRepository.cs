using DBEgzaminas_StudentuInfoSistema.Database.Entities;

namespace DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Department GetByCode(string code);
        IEnumerable<Department> GetAll();
        string Create(Department department);
        void Update(Department department);
        void Delete(string code);
        void SaveChanges();
    }
}
