using DBEgzaminas_StudentuInfoSistema.Database.Entities;

namespace DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Student? GetById(int id);
        IEnumerable<Student> GetAll();
        int Create(Student student);
        void Update(Student student);
        void Delete(int id);
        void SaveChanges();
    }
}
