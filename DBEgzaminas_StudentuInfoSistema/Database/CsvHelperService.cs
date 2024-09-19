using DBEgzaminas_StudentuInfoSistema.Database.Entities;
using DBEgzaminas_StudentuInfoSistema.Database.Models;

namespace DBEgzaminas_StudentuInfoSistema.Database
{
    public static class CsvHelperService
    {
        public static List<Department> GetDepartments()
        {
            var csv = File.ReadAllLines(@"..\..\..\Database\\InitialData\\departments.csv");
            var departments = new List<Department>();
            foreach (var line in csv.Skip(1))
            {
                var values = line.Split(',');
                var department = new Department
                {
                    DepartmentCode = values[0],
                    DepartmentName = values[1]
                };
                departments.Add(department);
            }

            return departments;
        }

        public static List<Lecture> GetLectures()
        {
            var csv = File.ReadAllLines(@"..\..\..\Database\\InitialData\\lectures.csv");
            var lectures = new List<Lecture>();
            foreach (var line in csv.Skip(1))
            {
                var values = line.Split(',');
                var lecture = new Lecture
                {
                    LectureId = int.Parse(values[0]),
                    LectureName = values[1],
                    StartTime = TimeOnly.ParseExact(Convert.ToString(values[2]).Substring(0, 5), "HH:mm"),
                    EndTime = TimeOnly.ParseExact(Convert.ToString(values[2]).Substring(6, 5), "HH:mm")
                };
                lectures.Add(lecture);
            }

            return lectures;
        }

        public static List<Student> GetStudents()
        {
            var csv = File.ReadAllLines(@"..\..\..\Database\\InitialData\\students.csv");
            var students = new List<Student>();
            foreach (var line in csv.Skip(1))
            {
                var values = line.Split(',');
                var student = new Student
                {
                    FirstName = values[0],
                    LastName = values[1],
                    StudentNumber = int.Parse(values[2]),
                    Email = values[3],
                    DepartmentCode = values[4]
                };
                students.Add(student);
            }

            return students;
        }

        public static List<DepartmentLecture> GetDepartmentsLectures()
        {
            var csv = File.ReadAllLines(@"..\..\..\Database\\InitialData\\department_lectures.csv");
            var departmentLectures = new List<DepartmentLecture>();
            foreach (var line in csv.Skip(1))
            {
                var values = line.Split(',');
                var departmentLecture = new DepartmentLecture
                {
                    DepartmentsDepartmentCode = values[0],
                    LecturesLectureId = int.Parse(values[1])
                };
                departmentLectures.Add(departmentLecture);
            }

            return departmentLectures;
        }

        public static List<LectureStudent> GetLecturesStudents()
        {
            var csv = File.ReadAllLines(@"..\..\..\Database\\InitialData\\student_lectures.csv");
            var lectureStudents = new List<LectureStudent>();
            foreach (var line in csv.Skip(1))
            {
                var values = line.Split(',');
                var lectureStudent = new LectureStudent
                {
                    StudentsStudentNumber = int.Parse(values[0]),
                    LecturesLectureId = int.Parse(values[1])
                };
                lectureStudents.Add(lectureStudent);
            }

            return lectureStudents;
        }
    }
}
