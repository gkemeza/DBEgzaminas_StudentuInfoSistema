using DBEgzaminas_StudentuInfoSistema.Database.Enums;

namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Lecture
    {
        public Lecture() { }

        public Lecture(string lectureName, TimeOnly startTime,
            TimeOnly endTime, Workday? weekday = null)
        {
            LectureName = lectureName;
            StartTime = startTime;
            EndTime = endTime;
            Weekday = weekday;
        }

        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public Workday? Weekday { get; set; }

        public ICollection<Department>? Departments { get; set; } = new List<Department>();
        public ICollection<Student>? Students { get; set; } = new List<Student>();

    }
}
