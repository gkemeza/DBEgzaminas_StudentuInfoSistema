using DBEgzaminas_StudentuInfoSistema.Database.Enums;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces;

namespace DBEgzaminas_StudentuInfoSistema.Services
{
    public class ValidationService
    {
        // +3 savo validacijos

        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILectureRepository _lectureRepository;
        private readonly IStudentRepository _studentRepository;

        public ValidationService(IDepartmentRepository departmentRepository,
            ILectureRepository lectureRepository, IStudentRepository studentRepository)
        {
            _departmentRepository = departmentRepository;
            _lectureRepository = lectureRepository;
            _studentRepository = studentRepository;
        }

        public bool IsValidStudentName(string name)
        {

            if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
            {
                return false;
            }

            if (name.Length < 2 || name.Length > 50)
            {
                return false;
            }

            return true;
        }

        public bool IsValidStudentNumber(string studentNumber)
        {
            if (studentNumber.Length != 8 || !studentNumber.All(char.IsDigit))
            {
                return false;
            }

            // Check if the student number is unique
            var student = _studentRepository.GetById(int.Parse(studentNumber));
            if (student != null)
            {
                return false;
            }

            return true;
        }

        public bool IsValidStudentEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Contains(' '))
            {
                return false;
            }

            int atIndex = email.IndexOf('@');
            if (atIndex < 1 || atIndex != email.LastIndexOf('@'))
            {
                return false;
            }

            int dotIndex = email.IndexOf('.', atIndex);
            if (dotIndex < atIndex + 2 || dotIndex == email.Length - 1)
            {
                return false;
            }

            // Check if the student email is unique
            var students = _studentRepository.GetAll();
            if (students.Any(x => x.Email == email))
            {
                return false;
            }

            return true;
        }

        public bool IsValidDepartmentName(string name)
        {
            if (name.Length < 3 || name.Length > 100)
            {
                return false;
            }

            if (!name.All(char.IsLetterOrDigit))
            {
                return false;
            }

            return true;
        }

        public bool IsValidDepartmentCode(string code)
        {
            if (code.Length != 6 || !code.All(char.IsLetterOrDigit))
            {
                return false;
            }

            // Check if the department code is unique
            var department = _departmentRepository.GetByCode(code);
            if (department != null)
            {
                return false;
            }

            return true;
        }

        public bool IsExistingDepartmentCode(string code)
        {
            return _departmentRepository.GetAll().Any(d => d.DepartmentCode == code);
        }

        public bool IsValidLectureName(string name)
        {
            if (name.Length < 5)
            {
                return false;
            }

            // Check if the lecture name is unique
            var lectures = _lectureRepository.GetAll();
            if (lectures.Any(x => x.LectureName == name))
            {
                return false;
            }

            return true;
        }

        public bool IsValidTime(string input, out TimeOnly time)
        {
            return TimeOnly.TryParseExact(input, "HH:mm", out time);
        }

        public bool IsValidLectureTime(TimeOnly startTime, TimeOnly endTime)
        {
            if (startTime >= endTime)
            {
                return false;
            }

            // Check for overlapping lectures
            foreach (var lecture in _lectureRepository.GetAll())
            {
                if ((startTime < lecture.EndTime && endTime > lecture.StartTime))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsValidLectureWeekday(string weekDay)
        {
            if (string.IsNullOrEmpty(weekDay))
            {
                return true; // Null means the lectures are scheduled for all workdays (Mon-Fri)
            }

            if (!Enum.IsDefined(typeof(Workday), weekDay))
            {
                return false;
            }

            return true;
        }
    }
}
