using DBEgzaminas_StudentuInfoSistema.Database.Entities;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DBEgzaminas_StudentuInfoSistema.Database.Repositories
{
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
}
