namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Departament
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
