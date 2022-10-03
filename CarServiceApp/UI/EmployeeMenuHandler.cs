using CarServiceApp.Entities;
using CarServiceApp.Repositories;
using CarServiceApp.Services;

namespace CarServiceApp.UI
{
    public class EmployeeMenuHandler : UserInputHandler, IEmployeeMenuHandler
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IEmployeesDetailsHandler _employeesDetailsProvider;

        public EmployeeMenuHandler(IRepository<Employee> employeeRepository, IEmployeesDetailsHandler employeesDetailsProvider)
        {
            _employeeRepository = employeeRepository;
            _employeesDetailsProvider = employeesDetailsProvider;
        }

        public void SelectYourOption()
        {
            bool endWorking = false;
            while (!endWorking)
            {
                Console.WriteLine("--- EMPLOYEES MENU --- \n");
                Console.WriteLine("1 - List of all employees\n");
                Console.WriteLine("2 - Add new employee\n");
                Console.WriteLine("3 - Find employee by id\n");
                Console.WriteLine("4 - Remove employee by id\n");
                Console.WriteLine("5 - Get more data about employees\n");
                Console.WriteLine("Q - Save Changes and go to main menu\n");

                var userInput = GetUserInput("Please select valid option \nPress key: 1, 2, 3, 4, 5 or Q: ").ToUpper();

                switch (userInput)
                {
                    case "1":
                        WriteAllToConsole(_employeeRepository);
                        break;
                    case "2":
                        AddNewEmployee(_employeeRepository);
                        break;
                    case "3":
                        FindEmployeeById(_employeeRepository);
                        break;
                    case "4":
                        RemoveEmployeeById(_employeeRepository);
                        break;
                    case "5":
                        _employeesDetailsProvider.GetEmployeesDetails();
                        break;
                    case "Q":
                        endWorking = CloseAndSave(_employeeRepository);
                        break;
                    default:
                        Console.WriteLine($"Invalid input. You have entered [{userInput}]. Please select valid option");
                        continue;
                }
            }
        }

        private void WriteAllToConsole(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine("\n--- List of all employees ---");
            var items = employeeRepository.GetAll();
            if (items.ToList().Count == 0)
            {
                Console.WriteLine("No employees found");
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private void AddNewEmployee(IRepository<Employee> employeeRepository)
        {
            var firstName = GetUserInput("First Name:");
            var lastName = GetUserInput("Last Name:");
            var dateOfBirth = GetUserInput("Date of birth: (eg. 1998,10,5");
            var startOfEmployment = GetUserInput("Date of employment: (eg. 2012,7,30");
            var salary = GetUserInput("Salary:");
            while (true)
            {
                var department = GetUserInput("Employee department:\n\tCustomer Service: 1\n\tSpare Parts: 2\n\tBody and Paint Workshop: 3\n\tMechanical Workshop: 4");
                int departmentValue;
                var isParsed = int.TryParse(department, out departmentValue);
                if (isParsed && departmentValue > 0 && departmentValue < 4)
                {
                    while (true)
                    {
                        var isManager = GetUserInput("Is employee the manager of the department?\nPress Y if YES\t\tPress N if NO").ToUpper();
                        if (isManager == "Y")
                        {
                            var newEmployee = new Employee
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                DateOfBirth = DateTime.Parse(dateOfBirth),
                                StartOfEmployment = DateTime.Parse(startOfEmployment),
                                Salary = decimal.Parse(salary),
                                Department = (Department)departmentValue,
                                IsManager = true
                            };
                            employeeRepository.Add(newEmployee);
                            break;
                        }
                        if (isManager == "N")
                        {
                            var newEmployee = new Employee
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                DateOfBirth = DateTime.Parse(dateOfBirth),
                                StartOfEmployment = DateTime.Parse(startOfEmployment),
                                Salary = decimal.Parse(salary),
                                Department = (Department)departmentValue,
                                IsManager = false
                            };
                            employeeRepository.Add(newEmployee);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You have to choose :)");
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("You have to choose the department from above. Try again");
                }
            }

        }

        private Employee? FindEmployeeById(IRepository<Employee> employeeRepository)
        {
            while (true)
            {
                var selectedId = GetUserInput("Enter the ID of the employee you want to find");
                int selectedIdValue;
                var isParsed = int.TryParse(selectedId, out selectedIdValue);
                if (!isParsed)
                {
                    Console.WriteLine("Please enter the number, not a string");
                }
                else
                {
                    var employee = employeeRepository.GetById(selectedIdValue);
                    if (employee != null)
                    {
                        Console.WriteLine(employee.ToString()!);
                    }
                    else
                    {
                        Console.WriteLine("There is no employee with given id\n");
                    }
                    return employee;
                }
            }
        }

        private void RemoveEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employeeSelected = FindEmployeeById(employeeRepository);
            if (employeeSelected != null)
            {
                while (true)
                {
                    Console.WriteLine("Ary you sure you want to delete this employee record");
                    var answer = GetUserInput("Press Y if YES\t\tPress N if NO").ToUpper();
                    if (answer == "Y")
                    {
                        employeeRepository.Remove(employeeSelected);
                        break;
                    }
                    else if (answer == "N")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have to choose :)");
                    }
                }
            }
        }

        private bool CloseAndSave(IRepository<Employee> employeeRepository)
        {
            while (true)
            {
                var answer = GetUserInput("Do you want to write changes to the file before leaving to main menu?\nPress Y if YES\t\tPress N if NO").ToUpper();
                if (answer == "Y")
                {
                    employeeRepository.Save("Employees");
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
