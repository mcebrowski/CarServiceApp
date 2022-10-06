using CarServiceApp.Services;

namespace CarServiceApp.UI
{
    public class MainMenuHandler : UserInputHandler, IMainMenuHandler
    {
        private readonly IEmployeeMenuHandler _employeeMenuHandler;
        private readonly IClientMenuHandler _clientMenuHandler;
        private readonly IXmlMenuHandler _xmlMenuHandler;

        public MainMenuHandler(IEmployeeMenuHandler employeeMenuHandler, IClientMenuHandler clientMenuHandler, IXmlMenuHandler xmlMenuHandler)
        {
            _employeeMenuHandler = employeeMenuHandler;
            _clientMenuHandler = clientMenuHandler;
            _xmlMenuHandler = xmlMenuHandler;
        }

        public void SelectMainOption()
        {
            bool EndWorking = false;
            while (!EndWorking)
            {
                Console.WriteLine("--- MAIN MENU ---\n");
                Console.WriteLine("1 - Work on employees database\n");
                Console.WriteLine("2 - Work on clients database\n");
                Console.WriteLine("3 - XML Files Addon\n");
                Console.WriteLine("Q - Close App\n");

                var userInput = GetUserInput("Please select valid option \nPress key: 1, 2 or Q").ToUpper();

                switch (userInput)
                {
                    case "1":
                        _employeeMenuHandler.SelectYourOption();
                        break;
                    case "2":
                        _clientMenuHandler.SelectYourOption();
                        break;
                    case "3":
                        _xmlMenuHandler.SelectYourOption();
                            break;
                    case "Q":
                        EndWorking = true;
                        break;
                    default:
                        Console.WriteLine($"Invalid input. You have entered [{userInput}]. Please select valid option");
                        continue;
                }
            }
            Console.WriteLine("\nGoobye, see you later");
        }


    }
}
