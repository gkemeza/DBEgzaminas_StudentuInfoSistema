using DBEgzaminas_StudentuInfoSistema.Database.Entities;
using DBEgzaminas_StudentuInfoSistema.Database.Enums;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces;
using DBEgzaminas_StudentuInfoSistema.Presentation;

namespace DBEgzaminas_StudentuInfoSistema.Services
{
    public class SystemService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILectureRepository _lectureRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly UserInterface _userInterface;

        public SystemService(IDepartmentRepository departmentRepository, ILectureRepository lectureRepository,
            IStudentRepository studentRepository, UserInterface userInterface)
        {
            _departmentRepository = departmentRepository;
            _lectureRepository = lectureRepository;
            _studentRepository = studentRepository;
            _userInterface = userInterface;
        }

        public string CreateDepartment()
        {
            string code = _userInterface.PromptForDepartmentCode();
            string name = _userInterface.PromptForDepartmentName();

            var department = new Department(code, name);
            return _departmentRepository.Create(department);
        }

        public int CreateLecture(int id, string name, TimeOnly startTime,
                        TimeOnly endTime, Workday? workday = null)
        {
            var lecture = new Lecture(id, name, startTime, endTime, workday);
            return _lectureRepository.Create(lecture);
        }

        public int CreateStudent(int studentNumber, string firstName,
                                string lastName, string email)
        {
            var student = new Student(studentNumber, firstName, lastName, email);
            return _studentRepository.Create(student);
        }

        public bool AddLectureToDepartment(string departmentCode, int lectureId)
        {
            var department = _departmentRepository.GetByCode(departmentCode);
            var lecture = _lectureRepository.GetById(lectureId);

            if (!department.Lectures.Contains(lecture))
            {
                department.Lectures.Add(lecture);
                _departmentRepository.SaveChanges();
                return true;
            }

            return false;
        }

        //??
        public bool AddStudentToDepartment()
        {
            _userInterface.PrintStudents();
            int studentNumber = _userInterface.PromptForStudentNumber();

            _userInterface.PrintDepartments();
            string departmentCode = _userInterface.PromptForDepartmentCode();

            var department = _departmentRepository.GetByCode(departmentCode);
            var student = _studentRepository.GetById(studentNumber);

            if (department.Students != null && student != null)
            {
                if (!department.Students.Contains(student))
                {
                    department.Students.Add(student);
                    _departmentRepository.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool AddStudentToLecture(int studentNumber, int lectureId)
        {
            var student = _studentRepository.GetById(studentNumber);
            var lecture = _lectureRepository.GetById(lectureId);

            if (!lecture.Students.Contains(student))
            {
                lecture.Students.Add(student);
                _departmentRepository.SaveChanges();
                return true;
            }

            return false;
        }

        public bool ChangeStudentDepartment(int studentNumber, string departmentCode)
        {
            var student = _studentRepository.GetById(studentNumber);
            var department = _departmentRepository.GetByCode(departmentCode);

            if (student.DepartmentCode != departmentCode)
            {
                student.Department = department;
                student.Lectures = department.Lectures;
                _departmentRepository.SaveChanges();
                return true;
            }

            return false;
        }

        public void PrintDepartmentStudents(string departmentCode)
        {
            var department = _departmentRepository.GetByCode(departmentCode);
            //gal eager loadig reik?

            if (department == null)
            {
                Console.WriteLine($"Department with Code {departmentCode} not found.");
                return;
            }

            if (!department.Lectures.Any())
            {
                Console.WriteLine($"{department.DepartmentName} has no lectures.");
                return;
            }

            foreach (var student in department.Students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} " +
                    $"({student.Email}) - {student.StudentNumber}");
            }
        }

        public void PrintDepartmentLectures(string departmentCode)
        {
            var department = _departmentRepository.GetByCode(departmentCode);

            if (department == null)
            {
                Console.WriteLine($"Department with Code {departmentCode} not found.");
                return;
            }

            if (!department.Lectures.Any())
            {
                Console.WriteLine($"{department.DepartmentName} has no lectures.");
                return;
            }

            foreach (var lecture in department.Lectures)
            {
                Console.WriteLine($"{lecture.LectureName} {lecture.StartTime} " +
                    $"({lecture.EndTime}) - {lecture.LectureId}");
            }
        }

        public void PrintLecturesByStudent(int studentNumber)
        {
            var student = _studentRepository.GetById(studentNumber);

            if (student == null)
            {
                Console.WriteLine($"Student with Number {studentNumber} not found.");
                return;
            }

            if (!student.Lectures.Any())
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is not enrolled in any lectures.");
                return;
            }

            Console.WriteLine($"{student.FirstName} {student.LastName} lectures:");
            foreach (var lecture in student.Lectures)
            {
                Console.WriteLine($"- {lecture}");
            }
        }

        //public void AddStudentsToDepartment(string departmentCode, IEnumerable<Student> students)
        //{
        //    var department = _departmentRepository.GetByCode(departmentCode);
        //    foreach (var student in students)
        //    {
        //        if (!department.Students.Contains(student))
        //        {
        //            department.Students.Add(student);
        //        }
        //    }
        //    _departmentRepository.SaveChanges();
        //}

        //public void AddLecturesToDepartment(string departmentCode, IEnumerable<Lecture> lectures)
        //{
        //    var department = _departmentRepository.GetByCode(departmentCode);
        //    foreach (var lecture in lectures)
        //    {
        //        if (!department.Lectures.Contains(lecture))
        //        {
        //            department.Lectures.Add(lecture);
        //            _departmentRepository.SaveChanges();
        //        }
        //    }
        //}


    }
}
