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
                    _userInterface.DisplayDepartmentsMenu();
                    break;
                case "2":
                    //StudentsMenu();
                    break;
                case "3":
                    //LecturesMenu();
                    break;
                case "q":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
