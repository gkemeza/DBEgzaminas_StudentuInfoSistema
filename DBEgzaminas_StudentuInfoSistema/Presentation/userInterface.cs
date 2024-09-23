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
            Console.WriteLine("4. View students");
            Console.WriteLine("5. View lectures");
            Console.WriteLine("q. Go back");
        }

        public void DisplayLecturesMenu()
        {
            Console.Clear();
            Console.WriteLine("***** Lectures *****\n");
            Console.WriteLine("Choose a function:");
            Console.WriteLine("1. Create lecture");
            Console.WriteLine("2. Add to department");
            Console.WriteLine("3. Add student");
            Console.WriteLine("q. Go back");
        }

        public void DisplayStudentsMenu()
        {
            Console.Clear();
            Console.WriteLine("***** Students *****\n");
            Console.WriteLine("Choose a function:");
            Console.WriteLine("1. Create student");
            Console.WriteLine("2. Add lecture");
            Console.WriteLine("3. Update department");
            Console.WriteLine("4. View lectures");
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

        public void PrintLectures()
        {
            var lectures = _lectureRepository.GetAll();

            Console.Clear();
            Console.WriteLine("->Lectures");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{lecture.LectureName} - {lecture.LectureId} ");
            }
        }

        public string PromptForDepartmentCode()
        {
            Console.WriteLine("Enter department code:");
            return Console.ReadLine();
        }

        public string PromptForName()
        {
            Console.WriteLine("Enter name:");
            return Console.ReadLine();
        }

        public int PromptForStudentNumber()
        {
            Console.WriteLine("Choose student number:");
            return int.Parse(Console.ReadLine());
        }

        public string PromptForStudentNumberString()
        {
            Console.WriteLine("Choose student number:");
            return Console.ReadLine();
        }

        public string PromptForFirstName()
        {
            Console.WriteLine("Enter first name:");
            return Console.ReadLine();
        }

        public string PromptForLastName()
        {
            Console.WriteLine("Enter last name:");
            return Console.ReadLine();
        }

        public string PromptForEmail()
        {
            Console.WriteLine("Enter email:");
            return Console.ReadLine();
        }

        public int PromptForLectureId()
        {
            Console.WriteLine("Choose lecture id:");
            return int.Parse(Console.ReadLine());
        }

        public string PromptForStartTime()
        {
            Console.WriteLine("Enter start time (HH:mm):");
            return Console.ReadLine();
        }

        public string PromptForEndTime()
        {
            Console.WriteLine("Enter end time (HH:mm):");
            return Console.ReadLine();
        }



    }
}
