using DBEgzaminas_StudentuInfoSistema.Database;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces;
using DBEgzaminas_StudentuInfoSistema.Services;

namespace DBEgzaminas_StudentuInfoSistema
{
    public class Program
    {
        static void Main(string[] args)
        {
            StudentsContext context = new StudentsContext();
            IDepartmentRepository departmentRepository = new DepartmentRepository(context);
            ILectureRepository lectureRepository = new LectureRepository(context);
            IStudentRepository studentRepository = new StudentRepository(context);
            SystemService systemService = new SystemService(
                departmentRepository, lectureRepository, studentRepository);

            systemService.Run();
        }
    }
}
