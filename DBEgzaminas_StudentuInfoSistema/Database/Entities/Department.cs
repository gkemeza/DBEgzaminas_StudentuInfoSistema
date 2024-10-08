﻿namespace DBEgzaminas_StudentuInfoSistema.Database.Entities
{
    public class Department
    {
        public Department() { }

        public Department(string departmentCode, string departmentName)
        {
            DepartmentCode = departmentCode;
            DepartmentName = departmentName;
        }

        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Student>? Students { get; set; } = new List<Student>();

        public ICollection<Lecture>? Lectures { get; set; } = new List<Lecture>();
    }
}
