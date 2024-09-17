namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public string DepartamentCode { get; set; }
        public Departament Departament { get; set; }
    }
}
