using DBEgzaminas_StudentuInfoSistema.Database.Entities;

namespace DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Department GetById(string code);
        IEnumerable<Department> GetAll();
        string Create(Department department);
        void Update(Department department);
        void Delete(int code);
        void SaveChanges();

    }

    public interface ILectureRepository
    {
    }

    public interface IStudentRepository
    {
    }
}
