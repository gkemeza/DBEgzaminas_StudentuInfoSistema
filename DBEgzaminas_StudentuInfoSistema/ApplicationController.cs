﻿using DBEgzaminas_StudentuInfoSistema.Presentation;
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

        // Skaito vartotojo pasirinkimą ir kviečia atitinkamą metodą
        private void CallChosenOptionMethod()
        {
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    HandleDepartmentsMenuInput();
                    break;
                case "2":
                    HandleStudentsMenuInput();
                    break;
                case "3":
                    HandleLecturesMenuInput();
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
                    _systemService.AddLectureToDepartment();
                    break;
                case "4":
                    _systemService.PrintDepartmentStudents();
                    break;
                case "5":
                    _systemService.PrintDepartmentLectures();
                    break;
                case "q":
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void HandleLecturesMenuInput()
        {
            _userInterface.DisplayLecturesMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _systemService.CreateLecture();
                    break;
                case "2":
                    _systemService.AddLectureToDepartment();
                    break;
                case "3":
                    _systemService.AddStudentToLecture();
                    break;
                case "q":
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void HandleStudentsMenuInput()
        {
            _userInterface.DisplayStudentsMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _systemService.CreateStudent();
                    break;
                case "2":
                    _systemService.AddStudentToLecture();
                    break;
                case "3":
                    _systemService.AddStudentToDepartment();
                    break;
                case "4":
                    _systemService.PrintLecturesByStudent();
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
