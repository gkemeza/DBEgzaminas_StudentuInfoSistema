namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Departament
    {
        public string DepartamentCode { get; set; }
        public string DepartamentName { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
