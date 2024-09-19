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

    public interface ILectureRepository
    {
        Lecture GetById(int id);
        IEnumerable<Lecture> GetAll();
        int Create(Lecture lecture);
        void Update(Lecture lecture);
        void Delete(int id);
        void SaveChanges();
    }

    public interface IStudentRepository
    {
        Student GetById(int id);
        IEnumerable<Student> GetAll();
        int Create(Student student);
        void Update(Student student);
        void Delete(int id);
        void SaveChanges();
    }
}
