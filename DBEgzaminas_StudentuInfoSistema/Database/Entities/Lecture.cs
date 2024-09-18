using DBEgzaminas_StudentuInfoSistema.Database.Enums;

namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Lecture
    {
        public Lecture() { }

        public Lecture(int lectureId, string lectureName, TimeOnly startTime,
            TimeOnly endTime, Workday? weekday = null)
        {
            LectureId = lectureId;
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

        public ICollection<Department> Departments { get; set; }
        public ICollection<Student>? Students { get; set; }

    }
}
