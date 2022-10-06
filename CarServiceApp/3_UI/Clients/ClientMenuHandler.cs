using CarServiceApp.DataProviders;
using CarServiceApp.Entities;
using CarServiceApp.Repositories;
using CarServiceApp.Services;

namespace CarServiceApp.UI
{
    public class ClientMenuHandler : UserInputHandler, IClientMenuHandler
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IClientsProvider _clientsProvider;

        public ClientMenuHandler(IRepository<Client> clientRepository, IClientsProvider clientsProvider)
        {
            _clientRepository = clientRepository;
            _clientsProvider = clientsProvider;
        }
        public void SelectYourOption()
        {
            bool inClientMenu = true;
            while (inClientMenu)
            {
                Console.WriteLine("--- CLIENTS MENU ---\n");
                Console.WriteLine("1 - List of all clients\n");
                Console.WriteLine("2 - Add new client\n");
                Console.WriteLine("3 - Find client by id\n");
                Console.WriteLine("4 - Show clients by department\n");
                Console.WriteLine("Q - Save changes and go back to main menu\n");

                var userInput = GetUserInput("Please select valid option \nPress key: 1, 2, 3, 4 or Q: ").ToUpper();

                switch (userInput)
                {
                    case "1":
                        WriteAllToConsole(_clientRepository);
                        break;
                    case "2":
                        AddNewClient(_clientRepository);
                        break;
                    case "3":
                        FindClientById(_clientRepository);
                        break;
                    case "4":
                        GetAllClientsFromDepartment();
                        break;
                    case "Q":
                        inClientMenu = CloseAndSave(_clientRepository);
                        break;
                    default:
                        Console.WriteLine($"Invalid input. You have entered [{userInput}]. Please select valid option");
                        continue;
                }
            }
        }

        private void GetAllClientsFromDepartment()
        {
            var department = GetUserInput("Please select the department:\n\tMechanical Workshop: 2\n\tBody and Paint Workshop: 3\n\tSpare Parts: 4");
            var isParsed = int.TryParse(department, out int departmentValue);
            if (isParsed && departmentValue >= 2 && departmentValue <= 4)
            {
                string departmentName = DetermineDepartmentName(departmentValue);
                Console.WriteLine($"\nList of clients from {departmentName}\n");
                var clients = _clientsProvider.ClientInDepartment(departmentName);
                foreach (var client in clients)
                {
                    Console.WriteLine(client);
                }
            }
            else
            {
                Console.WriteLine("Please enter valid department number");
            }
        }

        private static void WriteAllToConsole(IRepository<Client> clientRepository)
        {
            Console.WriteLine("\n--- List of all clients ---");
            var items = clientRepository.GetAll();
            if (items.ToList().Count == 0)
            {
                Console.WriteLine("No clients found");
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void AddNewClient(IRepository<Client> clientRepository)
        {
            var firstName = GetUserInput("First Name: ");
            var lastName = GetUserInput("Last name: ");
            while (true)
            {
                var department = GetUserInput("Client is in department:\n\tMechanical Workshop: 2\n\tBody and Paint Workshop: 3\n\tSpare Parts: 4");
                var isParsed = int.TryParse(department, out int departmentValue);
                if (isParsed && departmentValue >= 2 && departmentValue <= 4)
                {
                    string departmentName = DetermineDepartmentName(departmentValue);
                    var newClient = new Client
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Department = departmentName,
                    };
                    clientRepository.Add(newClient);
                    break;
                }
                else
                {
                    Console.WriteLine("You have to choose the department from above. Try again");
                }
            }
        }
        private static Client? FindClientById(IRepository<Client> clientRepository)
        {
            while (true)
            {
                var selectedId = GetUserInput("Enter the ID of the client you want to find");
                var isParsed = int.TryParse(selectedId, out int selectedValue);
                if (!isParsed)
                {
                    Console.WriteLine("Please enter the number, not a string");
                }
                else
                {
                    var client = clientRepository.GetById(selectedValue);
                    if (client != null)
                    {
                        Console.WriteLine(client.ToString());
                    }
                    else
                    {
                        Console.WriteLine("There is no client with given id\n");
                    }
                    return client;
                }
            }
        }

        private static bool CloseAndSave(IRepository<Client> clientRepository)
        {
            while (true)
            {
                var answer = GetUserInput("Do you want to write changes to the file before leaving to main menu?\nPress Y if YES\t\tPress N if NO").ToUpper();
                if (answer == "Y")
                {
                    clientRepository.Save("Clients");
                    Console.WriteLine("All changes has been saved in file successfully\n");
                    return false;
                }
                else if (answer == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("You have to choose :)");
                }
            }
        }
    }
}
