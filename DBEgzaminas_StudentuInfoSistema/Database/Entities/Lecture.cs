namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Lecture
    {
        public string LectureName { get; set; }
        public string LectureTime { get; set; }

        public ICollection<Departament> Departaments { get; set; }
    }
}
