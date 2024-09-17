namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public string LectureTime { get; set; }

        public ICollection<Departament> Departaments { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}
