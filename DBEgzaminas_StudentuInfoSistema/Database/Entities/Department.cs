namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Department
    {
        public Department() { }

        public Department(string departmentCode, string departmentName,
            ICollection<Student> students, ICollection<Lecture> lectures)
        {
            DepartmentCode = departmentCode;
            DepartmentName = departmentName;
            Students = students;
            Lectures = lectures;
        }

        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
