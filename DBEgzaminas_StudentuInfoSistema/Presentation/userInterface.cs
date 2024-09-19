using DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces;

namespace DBEgzaminas_StudentuInfoSistema.Presentation
{
    public class UserInterface
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILectureRepository _lectureRepository;
        private readonly IStudentRepository _studentRepository;

        public UserInterface(IDepartmentRepository departmentRepository,
            ILectureRepository lectureRepository, IStudentRepository studentRepository)
        {
            _departmentRepository = departmentRepository;
            _lectureRepository = lectureRepository;
            _studentRepository = studentRepository;
        }

        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("***** Students Info System *****\n");
            Console.WriteLine("Choose category:");
            Console.WriteLine("1. Departments");
            Console.WriteLine("2. Students");
            Console.WriteLine("3. Lectures");
            Console.WriteLine("q. Exit");
        }

        public void DisplayDepartmentsMenu()
        {
            Console.Clear();
            Console.WriteLine("***** Departments *****\n");
            Console.WriteLine("Choose a function:");
            Console.WriteLine("1. Create department");
            Console.WriteLine("2. Add students");
            Console.WriteLine("3. Add lectures");
            Console.WriteLine("q. Go back");
        }

        public void DisplayMessageAndWait(string message = "")
        {
            if (message != string.Empty)
            {
                Console.WriteLine(message);
            }
            Console.WriteLine("\nPress 'Enter' to continue...");
            Console.ReadLine();
        }

        public string PromptForDepartmentCode()
        {
            Console.WriteLine("Enter department code:");
            return Console.ReadLine();
        }

        public string PromptForDepartmentName()
        {
            Console.WriteLine("Enter department name:");
            return Console.ReadLine();
        }

        public void PrintStudents()
        {
            var students = _studentRepository.GetAll();

            Console.Clear();
            Console.WriteLine("->Students");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} " +
                    $"({student.Email}) - {student.StudentNumber}");
            }
        }

        public void PrintDepartments()
        {
            var departments = _departmentRepository.GetAll();

            Console.Clear();
            Console.WriteLine("->Departments");
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentName} - {department.DepartmentCode} ");
            }
        }

        public int PromptForStudentNumber()
        {
            Console.WriteLine("Choose student number:");
            return int.Parse(Console.ReadLine());
        }

    }
}
