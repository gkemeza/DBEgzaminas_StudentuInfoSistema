using DBEgzaminas_StudentuInfoSistema.Database.Enums;

namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public Weekday? Weekday { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}
