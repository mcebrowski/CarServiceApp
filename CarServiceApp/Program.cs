using CarServiceApp.Data;
using CarServiceApp.Entities;
using CarServiceApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new CarServiceAppDbContext());
var clientRepository = new SqlRepository<Client>(new CarServiceAppDbContext());

AddEmployees(employeeRepository);
AddManagers(employeeRepository);
RemoveEmployeeById(employeeRepository);
WriteAllToConsole(employeeRepository);

AddClients(clientRepository);
WriteAllToConsole(clientRepository);

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Wojtek", LastName = "Nowak" });
    employeeRepository.Add(new Employee { FirstName = "Monika", LastName = "Dziuba" });
    employeeRepository.Add(new Employee { FirstName = "Damian", LastName = "Bednarz" });
    employeeRepository.Save();
}

static void AddManagers(IWriteRepository<Manager> managerRepository)
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
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    Console.WriteLine(items);
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}




