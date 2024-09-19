namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Student
    {
        public Student() { }

        public Student(int studentNumber, string firstName,
            string lastName, string email)
        {
            StudentNumber = studentNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Lecture>? Lectures { get; set; }

        public string? DepartmentCode { get; set; }
        public Department? Department { get; set; }
    }
}
