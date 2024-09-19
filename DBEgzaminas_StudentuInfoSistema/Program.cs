using DBEgzaminas_StudentuInfoSistema.Database;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces;
using DBEgzaminas_StudentuInfoSistema.Presentation;
using DBEgzaminas_StudentuInfoSistema.Services;

namespace DBEgzaminas_StudentuInfoSistema
{
    public class Program
    {
        static void Main(string[] args)
        {
            SystemContext context = new SystemContext();
            IDepartmentRepository departmentRepository = new DepartmentRepository(context);
            ILectureRepository lectureRepository = new LectureRepository(context);
            IStudentRepository studentRepository = new StudentRepository(context);
            UserInterface userInterface = new UserInterface();
            SystemService systemService = new SystemService(
                departmentRepository, lectureRepository, studentRepository, userInterface);
            ApplicationController controller = new ApplicationController(systemService, userInterface);

            controller.Run();
        }
    }
}
