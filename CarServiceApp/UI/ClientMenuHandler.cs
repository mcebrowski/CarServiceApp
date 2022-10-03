using CarServiceApp.Entities;
using CarServiceApp.Repositories;
using CarServiceApp.Services;

namespace CarServiceApp.UI
{
    public class ClientMenuHandler : UserInputHandler, IClientMenuHandler
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientMenuHandler(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public void SelectYourOption()
        {
            bool endWorking = false;
            while (!endWorking)
            {
                Console.WriteLine("--- CLIENTS MENU ---\n");
                Console.WriteLine("1 - List of all clients\n");
                Console.WriteLine("2 - Add new client\n");
                Console.WriteLine("3 - Find client by id\n");
                Console.WriteLine("4 - Get more data about clients\n");
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
                        // to implement :)
                        break;
                    case "Q":
                        endWorking = CloseAndSave(_clientRepository);
                        break;
                    default:
                        Console.WriteLine($"Invalid input. You have entered [{userInput}]. Please select valid option");
                        continue;
                }
            }
        }

        private void WriteAllToConsole(IRepository<Client> clientRepository)
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

        private void AddNewClient(IRepository<Client> clientRepository)
        {
            var firstName = GetUserInput("First Name: ");
            var lastName = GetUserInput("Last name: ");
            while (true)
            {
                var department = GetUserInput("Client is in department:\n\tSpare Parts: 1\n\tBody and Paint workshop: 2\n\tMechanical Workshop: 3");
                int departmentValue;
                var isParsed = int.TryParse(department, out departmentValue);
                if (isParsed && departmentValue > 0 && departmentValue <= 4)
                {
                    var newClient = new Client
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Department = (Department)departmentValue,
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
        private Client? FindClientById(IRepository<Client> clientRepository)
        {
            while (true)
            {
                var selectedId = GetUserInput("Enter the ID of the client you want to find");
                int selectedValue;
                var isParsed = int.TryParse(selectedId, out selectedValue);
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

        private bool CloseAndSave(IRepository<Client> clientRepository)
        {
            while (true)
            {
                var answer = GetUserInput("Do you want to write changes to the file before leaving to main menu?\nPress Y if YES\t\tPress N if NO").ToUpper();
                if (answer == "Y")
                {
                    clientRepository.Save("Clients");
                    Console.WriteLine("All changes has been saved in file successfully\n");
                    return true;
                }
                else if (answer == "N")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("You have to choose :)");
                }
            }
        }

    }
}
