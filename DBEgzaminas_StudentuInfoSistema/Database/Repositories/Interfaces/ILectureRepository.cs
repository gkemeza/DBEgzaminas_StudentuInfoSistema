using DBEgzaminas_StudentuInfoSistema.Database.Entities;

namespace DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces
{
    public interface ILectureRepository
    {
        Lecture GetById(int id);
        IEnumerable<Lecture> GetAll();
        int Create(Lecture lecture);
        void Update(Lecture lecture);
        void Delete(int id);
        void SaveChanges();
    }
}
