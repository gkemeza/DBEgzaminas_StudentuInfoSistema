using DBEgzaminas_StudentuInfoSistema.Database.Enums;

namespace DBEgzaminas_StudentuInfoSistema.Services
{
    public class ValidationService
    {
        // +3 savo validacijos

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

            // Check if the student number is unique (with repo)

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

            // Check if the student email is unique (with repo)

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

            // Check if the department code is unique (with repo)

            return true;
        }

        public bool IsValidLectureName(string name)
        {
            if (name.Length < 5)
            {
                return false;
            }

            // Check if the lecture name is unique (with repo)

            return true;
        }

        public bool IsValidLectureTime(string time)
        {
            if (!TimeOnly.TryParseExact(Convert.ToString(time).Substring(0, 5), "HH:mm", out TimeOnly startTime))
            {
                return false;
            }

            if (!TimeOnly.TryParseExact(Convert.ToString(time).Substring(6, 5), "HH:mm", out TimeOnly endTime))
            {
                return false;
            }

            if (startTime <= endTime)
            {
                return false;
            }

            // Check if the lecture time in the same department is unique (with repo)

            return true;
        }

        public bool IsValidLectureWeekday(string weekDay)
        {
            if (!Enum.IsDefined(typeof(Workday), weekDay))
            {
                return false;
            }

            return true;
        }
    }
}
