﻿namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Student
    {
        public Student() { }

        public Student(string firstName, string lastName,
            string email, string departmentCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DepartmentCode = departmentCode;
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
