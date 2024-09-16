namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Departament
    {
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
