using DBEgzaminas_StudentuInfoSistema.Presentation;
using DBEgzaminas_StudentuInfoSistema.Services;

namespace DBEgzaminas_StudentuInfoSistema
{
    public class ApplicationController
    {
        private readonly SystemService _systemService;
        private readonly UserInterface _userInterface;

        public ApplicationController(SystemService systemService, UserInterface userInterface)
        {
            _systemService = systemService;
            _userInterface = userInterface;
        }

        public void Run()
        {
            while (true)
            {
                _userInterface.DisplayMainMenu();
                CallChosenOptionMethod();
            }
        }

        private void CallChosenOptionMethod()
        {
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    HandleDepartmentsMenuInput();
                    break;
                case "2":
                    //HandleStudentsMenuInput();
                    break;
                case "3":
                    //HandleLecturesMenuInput();
                    break;
                case "q":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private void HandleDepartmentsMenuInput()
        {
            _userInterface.DisplayDepartmentsMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _systemService.CreateDepartment();
                    break;
                case "2":
                    _systemService.AddStudentToDepartment();
                    break;
                case "3":
                    //AddLectures();
                    break;
                case "q":
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
