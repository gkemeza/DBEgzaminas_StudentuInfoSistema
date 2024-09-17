namespace DBEgzaminas_StudentuInfoSistema.Services
{
    // duomenu validacijos metodai
    public class ValidationService
    {
        public bool IsValidStudentName(string name)
        {
            return
               !string.IsNullOrWhiteSpace(name) &&
               name.Length >= 2 &&
               name.Length <= 50 &&
               name.All(char.IsLetter);
        }

        public bool IsValidStudentNumber(string studentNumber)
        {
            // Validate length and that it's all digits
            if (studentNumber.Length != 8 || !studentNumber.All(char.IsDigit))
            {
                return false;
            }

            // Check if the student number is unique
            return true;
        }
    }
}
