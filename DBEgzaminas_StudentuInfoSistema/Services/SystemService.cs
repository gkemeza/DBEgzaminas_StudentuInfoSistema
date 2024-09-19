using DBEgzaminas_StudentuInfoSistema.Database.Entities;
using DBEgzaminas_StudentuInfoSistema.Database.Enums;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces;

namespace DBEgzaminas_StudentuInfoSistema.Services
{
    public class SystemService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public SystemService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // make create and add into diff methods
        public Department CreateDepartment(string code, string name, ICollection<Student> students, ICollection<Lecture> lectures)
        {
            var department = new Department(code, name, students, lectures);
            _departmentRepository.Create(department);
            return department;
        }

        public void AddStudentsToDepartment(string departmentCode, IEnumerable<Student> students)
        {
            var department = _departmentRepository.GetByCode(departmentCode);
            foreach (var student in students)
            {
                if (!department.Students.Contains(student))
                {
                    department.Students.Add(student);
                }
            }
            _departmentRepository.SaveChanges();
        }

        public void AddLecturesToDepartment(string departmentCode, IEnumerable<Lecture> lectures)
        {
            var department = _departmentRepository.GetByCode(departmentCode);
            foreach (var lecture in lectures)
            {
                if (!department.Lectures.Contains(lecture))
                {
                    department.Lectures.Add(lecture);
                }
            }
            _departmentRepository.SaveChanges();
        }

        public Lecture CreateLecture(int id, string name,
            TimeOnly startTime, TimeOnly endTime, Workday? workday = null)
        {
            var lecture = new Lecture(id, name, startTime, endTime, workday);
            // add to DB
            return lecture;
        }

    }
}
