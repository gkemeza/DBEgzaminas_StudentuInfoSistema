namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Department
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
