namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentNumber { get; set; }
        public string Email { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }
    }
}
