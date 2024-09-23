using DBEgzaminas_StudentuInfoSistema.Database.Entities;
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
            string name = _userInterface.PromptForName();

            var department = new Department(code, name);
            return _departmentRepository.Create(department);
        }

        public int CreateLecture()
        {
            string name = _userInterface.PromptForName();
            TimeOnly startTime = _userInterface.PromptForStartTime();
            TimeOnly endTime = _userInterface.PromptForEndTime();

            var lecture = new Lecture(name, startTime, endTime);
            return _lectureRepository.Create(lecture);
        }

        public int CreateStudent()
        {
            string firstName = _userInterface.PromptForFirstName();
            string lastName = _userInterface.PromptForLastName();
            string email = _userInterface.PromptForEmail();
            _userInterface.PrintDepartments();
            string departmentCode = _userInterface.PromptForDepartmentCode();

            var student = new Student(firstName, lastName, email, departmentCode);
            return _studentRepository.Create(student);
        }

        public bool AddLectureToDepartment()
        {
            _userInterface.PrintLectures();
            int lectureId = _userInterface.PromptForLectureId();

            _userInterface.PrintDepartments();
            string departmentCode = _userInterface.PromptForDepartmentCode();

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

        public bool AddStudentToLecture()
        {
            _userInterface.PrintLectures();
            int lectureId = _userInterface.PromptForLectureId();

            _userInterface.PrintStudents();
            int studentNumber = _userInterface.PromptForStudentNumber();

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

        public bool ChangeStudentDepartment()
        {
            _userInterface.PrintStudents();
            int studentNumber = _userInterface.PromptForStudentNumber();

            _userInterface.PrintDepartments();
            string departmentCode = _userInterface.PromptForDepartmentCode();

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

        public void PrintDepartmentStudents()
        {
            _userInterface.PrintDepartments();
            string departmentCode = _userInterface.PromptForDepartmentCode();

            var department = _departmentRepository.GetByCode(departmentCode);
            //gal eager loading reik?

            if (department == null)
            {
                Console.WriteLine($"Department with Code {departmentCode} not found.");
                _userInterface.DisplayMessageAndWait();
                return;
            }

            if (!department.Students.Any())
            {
                Console.WriteLine($"{department.DepartmentName} has no students.");
                _userInterface.DisplayMessageAndWait();
                return;
            }

            Console.WriteLine();
            foreach (var student in department.Students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} " +
                    $"({student.Email})");
            }
            _userInterface.DisplayMessageAndWait();
        }

        public void PrintDepartmentLectures()
        {
            _userInterface.PrintDepartments();
            string departmentCode = _userInterface.PromptForDepartmentCode();

            var department = _departmentRepository.GetByCode(departmentCode);

            if (department == null)
            {
                Console.WriteLine($"Department with Code {departmentCode} not found.");
                _userInterface.DisplayMessageAndWait();
                return;
            }

            if (!department.Lectures.Any())
            {
                Console.WriteLine($"{department.DepartmentName} has no lectures.");
                _userInterface.DisplayMessageAndWait();
                return;
            }

            Console.WriteLine();
            foreach (var lecture in department.Lectures)
            {
                Console.WriteLine($"{lecture.LectureName} ({lecture.StartTime}-" +
                    $"{lecture.EndTime})");
            }
            _userInterface.DisplayMessageAndWait();
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
    }
}
