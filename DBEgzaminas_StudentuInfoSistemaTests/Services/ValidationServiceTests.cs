using DBEgzaminas_StudentuInfoSistema.Database.Repositories.Interfaces;
using DBEgzaminas_StudentuInfoSistema.Database.Repositories;
using DBEgzaminas_StudentuInfoSistema.Database;
using DBEgzaminas_StudentuInfoSistema.Database.Entities;
using Microsoft.EntityFrameworkCore;
using DBEgzaminas_StudentuInfoSistema.Presentation;

namespace DBEgzaminas_StudentuInfoSistema.Services.Tests
{
    [TestClass()]
    public class ValidationServiceTests
    {
        private ValidationService _validator;
        private IDepartmentRepository _departmentRepository;
        private ILectureRepository _lectureRepository;
        private IStudentRepository _studentRepository;
        private SystemContext _context;
        private SystemService _systemService;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<SystemContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new SystemContext(options);
            _departmentRepository = new DepartmentRepository(_context);
            _lectureRepository = new LectureRepository(_context);
            _studentRepository = new StudentRepository(_context);
            _validator = new ValidationService(
                _departmentRepository, _lectureRepository, _studentRepository);
            UserInterface userInterface = new UserInterface(
                _departmentRepository, _lectureRepository, _studentRepository);
            _systemService = new SystemService(
                _departmentRepository, _lectureRepository, _studentRepository, userInterface, _validator);

            _departmentRepository.Create(new Department("CS1234", "ComputerScience"));
            Student jonas = new Student(12345678, "Jonas", "Jonaitis", "alice.johnson@example.com", "CS1234");
            _studentRepository.Create(jonas);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public void IsValidStudentName_InvalidName_ReturnsFalse()
        {
            // Arrange
            string name = "Jo1n";
            string surname = "Sm!th";

            // Act
            bool result = _validator.IsValidStudentName(name);
            bool result2 = _validator.IsValidStudentName(surname);

            // Assert
            Assert.IsFalse(result, "Expected false for name containing numbers.");
            Assert.IsFalse(result2, "Expected false for invalid surname.");
        }

        [TestMethod]
        public void IsValidStudentName_TooShortName_ReturnsFalse()
        {
            // Arrange
            string name = "J";
            string surname = "Smith";

            // Act
            bool result = _validator.IsValidStudentName(name);
            bool result2 = _validator.IsValidStudentName(surname);

            // Assert
            Assert.IsFalse(result, "Expected false for name shorter than 2 characters.");
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void IsValidStudentName_TooLongName_ReturnsFalse()
        {
            // Arrange
            string name = "JohnathonJohnathonJohnathonJohnathonJohnathonJonath"; // 51 characters
            string surname = "Smith";

            // Act
            bool result = _validator.IsValidStudentName(name);
            bool result2 = _validator.IsValidStudentName(surname);

            // Assert
            Assert.IsFalse(result, "Expected false for name longer than 50 characters.");
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void IsValidStudentName_EmptyOrNull_ReturnsFalse()
        {
            // Arrange
            string name = ""; // 51 characters
            string surname = null;

            // Act
            bool result = _validator.IsValidStudentName(name);
            bool result2 = _validator.IsValidStudentName(surname);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void IsValidStudentNumber_TooShort_ReturnsFalse()
        {
            // Arrange
            string studentNumber = "1234567"; // 7 digits

            // Act
            bool result = _validator.IsValidStudentNumber(studentNumber);

            // Assert
            Assert.IsFalse(result, "Expected false for student number shorter than 8 digits.");
        }

        [TestMethod]
        public void IsValidStudentNumber_TooLong_ReturnsFalse()
        {
            // Arrange
            string studentNumber = "123456789"; // 9 digits

            // Act
            bool result = _validator.IsValidStudentNumber(studentNumber);

            // Assert
            Assert.IsFalse(result, "Expected false for student number longer than 8 digits.");
        }

        [TestMethod]
        public void IsValidStudentNumber_ContainsLetters_ReturnsFalse()
        {
            // Arrange
            string studentNumber = "1234ABCD";

            // Act
            bool result = _validator.IsValidStudentNumber(studentNumber);

            // Assert
            Assert.IsFalse(result, "Expected false for student number containing letters.");
        }

        [TestMethod]
        public void IsValidStudentNumber_AlreadyExists_ReturnsFalse()
        {
            // Arrange
            string studentNumber = "12345678"; // Already exists in DB

            // Act
            bool result = _validator.IsValidStudentNumber(studentNumber);

            // Assert
            Assert.IsFalse(result, "Expected false for already existing student number.");
        }

        [TestMethod]
        public void IsValidStudentNumber_TooShortAndContainsLetters_ReturnsFalse()
        {
            // Arrange
            string studentNumber = "ABC"; // 3 characters

            // Act
            bool result = _validator.IsValidStudentNumber(studentNumber);

            // Assert
            Assert.IsFalse(result, "Expected false for student number shorter than 8 digits and containing letters.");
        }

        [TestMethod]
        public void IsValidStudentEmail_MissingAtSymbol_ReturnsFalse()
        {
            // Arrange
            string email = "john.smithexample.com"; // Missing '@'

            // Act
            bool result = _validator.IsValidStudentEmail(email);

            // Assert
            Assert.IsFalse(result, "Expected false for email missing '@'.");
        }

        [TestMethod]
        public void IsValidStudentEmail_MissingDomain_ReturnsFalse()
        {
            // Arrange
            string email = "john.smith@"; // Missing domain

            // Act
            bool result = _validator.IsValidStudentEmail(email);

            // Assert
            Assert.IsFalse(result, "Expected false for email missing domain.");
        }

        [TestMethod]
        public void IsValidStudentEmail_MissingLocalPart_ReturnsFalse()
        {
            // Arrange
            string email = "@example.com"; // Missing local part

            // Act
            bool result = _validator.IsValidStudentEmail(email);

            // Assert
            Assert.IsFalse(result, "Expected false for email missing local part.");
        }

        [TestMethod]
        public void IsValidStudentEmail_MissingDomainEnd_ReturnsFalse()
        {
            // Arrange
            string email = "john.smith@example"; // Missing domain ending

            // Act
            bool result = _validator.IsValidStudentEmail(email);

            // Assert
            Assert.IsFalse(result, "Expected false for email missing domain ending.");
        }

        [TestMethod]
        public void IsValidStudentEmail_DomainEndsWithDot_ReturnsFalse()
        {
            // Arrange
            string email = "john.smith@example."; // Domain ends with dot

            // Act
            bool result = _validator.IsValidStudentEmail(email);

            // Assert
            Assert.IsFalse(result, "Expected false for email with domain ending with dot.");
        }

        [TestMethod]
        public void IsValidStudentEmail_EmptyEmail_ReturnsFalse()
        {
            // Arrange
            string email = ""; // Empty email

            // Act
            bool result = _validator.IsValidStudentEmail(email);

            // Assert
            Assert.IsFalse(result, "Expected false for empty email.");
        }

        [TestMethod]
        public void IsValidStudentEmail_DuplicateEmail_ReturnsFalse()
        {
            // Arrange
            string email = "alice.johnson@example.com"; // duplicate email

            // Act
            bool secondCheck = _validator.IsValidStudentEmail(email); // Check for the duplicate email

            // Assert
            Assert.IsFalse(secondCheck, "Expected false for duplicate email.");
        }

        [TestMethod]
        public void IsValidDepartmentName_TooShort_ReturnsFalse()
        {
            // Arrange
            string name = "CS"; // 2 characters

            // Act
            bool result = _validator.IsValidDepartmentName(name);

            // Assert
            Assert.IsFalse(result, "Expected false for department name shorter than 3 characters.");
        }

        [TestMethod]
        public void IsValidDepartmentName_WithSpecialCharacters_ReturnsFalse()
        {
            // Arrange
            string name = "Computer Science & Engineering"; // Contains special characters

            // Act
            bool result = _validator.IsValidDepartmentName(name);

            // Assert
            Assert.IsFalse(result, "Expected false for department name with special characters.");
        }

        [TestMethod]
        public void IsValidDepartmentName_ValidName_ReturnsTrue()
        {
            // Arrange
            string name = "ComputerScience123"; // Valid name

            // Act
            bool result = _validator.IsValidDepartmentName(name);

            // Assert
            Assert.IsTrue(result, "Expected true for valid department name.");
        }

        [TestMethod]
        public void IsValidDepartmentCode_TooShort_ReturnsFalse()
        {
            // Arrange
            string code = "CS12"; // 4 characters

            // Act
            bool result = _validator.IsValidDepartmentCode(code);

            // Assert
            Assert.IsFalse(result, "Expected false for department code shorter than 6 characters.");
        }

        [TestMethod]
        public void IsValidDepartmentCode_WithSpecialCharacters_ReturnsFalse()
        {
            // Arrange
            string code = "CS123@"; // Contains special character

            // Act
            bool result = _validator.IsValidDepartmentCode(code);

            // Assert
            Assert.IsFalse(result, "Expected false for department code with special characters.");
        }

        [TestMethod]
        public void IsValidDepartmentCode_DuplicateCode_ReturnsFalse()
        {
            // Arrange
            string code = "CS1234"; // Already exists in the repository

            // Act
            bool result = _validator.IsValidDepartmentCode(code);

            // Assert
            Assert.IsFalse(result, "Expected false for duplicate department code.");
        }

        [TestMethod]
        public void IsValidDepartmentCode_ValidCode_ReturnsTrue()
        {
            // Arrange
            string code = "CS9999"; // Valid and unique code

            // Act
            bool result = _validator.IsValidDepartmentCode(code);

            // Assert
            Assert.IsTrue(result, "Expected true for valid and unique department code.");
        }

        [TestMethod]
        public void IsValidLectureName_TooShort_ReturnsFalse()
        {
            // Arrange
            string name = "Math"; // 4 characters

            // Act
            bool result = _validator.IsValidLectureName(name);

            // Assert
            Assert.IsFalse(result, "Expected false for lecture name shorter than 5 characters.");
        }

        [TestMethod]
        public void IsValidLectureTime_EndTimeBeforeStartTime_ReturnsFalse()
        {
            // Arrange
            TimeOnly startTime = new TimeOnly(14, 0); // 14:00
            TimeOnly endTime = new TimeOnly(13, 0); // 13:00

            // Act
            bool result = _validator.IsValidLectureTime(startTime, endTime);

            // Assert
            Assert.IsFalse(result, "Expected false for end time earlier than start time.");
        }

        [TestMethod]
        public void IsValidLectureTime_OverlappingLectures_ReturnsFalse()
        {
            // Arrange
            TimeOnly startTime1 = new TimeOnly(10, 0); // 10:00
            TimeOnly endTime1 = new TimeOnly(11, 30); // 11:30
            TimeOnly startTime2 = new TimeOnly(11, 0); // 11:00
            TimeOnly endTime2 = new TimeOnly(12, 30); // 12:30
            _lectureRepository.Create(new Lecture("test", startTime1, endTime1));

            // Act
            bool result = _validator.IsValidLectureTime(startTime2, endTime2);

            // Assert
            Assert.IsFalse(result, "Expected false for overlapping lecture times.");
        }

        [TestMethod]
        public void IsValidLectureWeekday_InvalidWeekday_ReturnsFalse()
        {
            // Arrange
            string weekDay = "Sunday"; // Invalid day for lectures

            // Act
            bool result = _validator.IsValidLectureWeekday(weekDay);

            // Assert
            Assert.IsFalse(result, "Expected false for an invalid weekday.");
        }

        [TestMethod]
        public void IsValidLectureWeekday_ValidWeekday_ReturnsTrue()
        {
            // Arrange
            string weekDay = "Monday"; // Valid day for lectures

            // Act
            bool result = _validator.IsValidLectureWeekday(weekDay);

            // Assert
            Assert.IsTrue(result, "Expected true for a valid weekday.");
        }

        [TestMethod]
        public void IsValidLectureWeekday_NullWeekday_ReturnsTrue()
        {
            // Arrange
            string weekDay = null; // Null should allow all weekdays from Monday to Friday

            // Act
            bool result = _validator.IsValidLectureWeekday(weekDay);

            // Assert
            Assert.IsTrue(result, "Expected true for null (lectures occur from Monday to Friday).");
        }
    }

}