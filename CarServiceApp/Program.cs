using CarServiceApp.Data;
using CarServiceApp.Entities;
using CarServiceApp.Repositories;
using CarServiceApp.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new CarServiceAppDbContext());
//var clientRepository = new SqlRepository<Client>(new CarServiceAppDbContext());

employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
LoadAllDataFromFile(employeeRepository);

void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
{
    Console.WriteLine($" Employee added => {e.FirstName} {e.LastName} from {sender?.GetType().Name}");
}

var firstName = "";
var lastName = "";
var idToDelete = "";

Console.WriteLine("\n***** Welcome to Car Service Application *****");

while (true)
{
    Console.WriteLine($"\n--- What would you like to do? ---\n\n1. List all employees\n2. Add new employee\n3. Add default employees with batch\n4. Remove employee by id\n5. Save all work to file\n6. Exit application");
    string selectedOption = Console.ReadLine();
    SelectedOption(selectedOption);
}


void SelectedOption(string selectedOption)
{

    switch (selectedOption)
    {
        case "1":
            Console.WriteLine($"\n--- List of all employees ---");
            WriteAllToConsole(employeeRepository);
            break;
        case "2":
            Console.WriteLine($"\n Please enter employee first name");
            firstName = Console.ReadLine();
            Console.WriteLine($"\n Please enter employee last name");
            lastName = Console.ReadLine();
            AddEmployee(employeeRepository);
            break;
        case "3":
            AddEmployees(employeeRepository);
            break;
        case "4":
            Console.WriteLine($"\n Please enter id of employee which you would like to delete");
            idToDelete = Console.ReadLine();
            RemoveEmployeeById(employeeRepository);
            break;
        case "5":
            SaveAllDataToFile(employeeRepository);
            break;
        case "6":
            Console.WriteLine("Goodbye, see you later");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine($"Invalid input. You have entered: [{selectedOption}]. Please select valid option.");
            break;
    }
}


//AddEmployees(employeeRepository);
//AddManagers(employeeRepository);
//RemoveEmployeeById(employeeRepository);
//WriteAllToConsole(employeeRepository);

//AddClients(clientRepository);
//WriteAllToConsole(clientRepository);


void AddEmployee(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = firstName, LastName = lastName });
    employeeRepository.Save();
}

void SaveAllDataToFile(IRepository<Employee> employeeRepository)
{
    employeeRepository.SaveToFile();
}

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    var employees = new[]
    {
        new Employee { FirstName = "Anna", LastName = "Nowakowska" },
        new Employee { FirstName = "Monika", LastName = "Dziuba" },
        new Employee { FirstName = "Damian", LastName = "Bednarz" }
    };
    employeeRepository.AddBatch(employees);
}


static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

void LoadAllDataFromFile(IReadRepository<IEntity> repository)
{

    repository.LoadDataFromFile();
}

void RemoveEmployeeById(IRepository<Employee> employeeRepository)
{
    int id;
    int.TryParse(idToDelete, out id);

    if (id != 0)
    {
        Console.WriteLine($"Id to delete: {idToDelete}");
        var empToDelete = employeeRepository.GetById(Int32.Parse(idToDelete));
        Console.WriteLine(empToDelete);
        employeeRepository.Remove(empToDelete);
        employeeRepository.Save();
    }
    else
    {
        Console.WriteLine("Invalid value. Please enter valid id");
    }
}


/*static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Kamil", LastName = "Pawlak" });
    managerRepository.Add(new Manager { FirstName = "Zbigniew", LastName = "Wolny" });
    managerRepository.Save();
}

static void RemoveEmployeeById(IRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetById(2);
    Console.WriteLine($"Deleted employee: {employee}");
    employeeRepository.Remove(employee);
    employeeRepository.Save();
}

static void AddClients(IRepository<Client> clientRepository)
{
    clientRepository.Add(new Client { FirstName = "Dominika", LastName = "Jasińska" });
    clientRepository.Add(new Client { FirstName = "Waldemar", LastName = "Jasny" });
    clientRepository.Add(new Client { FirstName = "Marcin", LastName = "Kowalski" });
    clientRepository.Save();
}*/



