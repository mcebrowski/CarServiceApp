using CarServiceApp.DataProviders;
using CarServiceApp.Services;

namespace CarServiceApp.UI
{
    public class EmployeesDetailsHandler : UserInputHandler, IEmployeesDetailsHandler
    {
        private readonly IEmployeesProvider _employeesProvider;
        public EmployeesDetailsHandler(IEmployeesProvider employeesProvider)
        {
            _employeesProvider = employeesProvider;
        }

        public void GetEmployeesDetails()
        {
            bool inThisMenu = true;

            while (inThisMenu)
            {
                Console.WriteLine("--- WHAT WOULD YOU LIKE TO DO ---");
                Console.WriteLine("1 - Get uniqe departments\n");
                Console.WriteLine("2 - Get minimum salary\n");
                Console.WriteLine("3 - Order employees by last name and first name\n");
                Console.WriteLine("4 - Order employees by salary descending\n");
                Console.WriteLine("5 - Order employees by date of employment\n");
                Console.WriteLine("6 - Employees where minimum salary is greater then...>\n");
                Console.WriteLine("7 - Employees older then...>\n");
                Console.WriteLine("8 - Employees which are in department...>\n");
                Console.WriteLine("Q - Go back to MAIN MENU\n");

                var userInput = GetUserInput("Please choose:\nPress key 1, 2, 3, 4, 5, 6, 7, 8 or Q").ToUpper();

                switch (userInput)
                {
                    case "1":
                        GetUniqueDepartment();
                        break;
                    case "2":
                        GetMinSalary();
                        break;
                    case "3":
                        OrderByLastNameAndFirstName();
                        break;
                    case "4":
                        OrderBySalary();
                        break;
                    case "5":
                        OrderByStartOfEmployment();
                        break;
                    case "6":
                        GetEmployeesWhereMinimumSalaryGreaterThen();
                        break;
                    case "7":
                        GetEmployeesOlderThen();
                        break;
                    case "8":
                        GetAllEmployeesFromDepartment();
                        break;
                    case "Q":
                        inThisMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select valid option\n");
                        continue;
                }
            }
        }

        private void GetUniqueDepartment()
        {
            Console.WriteLine("\nDepartments in company:\n");
            var departments = _employeesProvider.GetUniqueDepartment();
            foreach (var department in departments)
            {
                Console.WriteLine($"{department}\n");
            }
        }

        private void GetMinSalary()
        {
            Console.WriteLine($"\nMinimum salary in company is: {_employeesProvider.GetMinimumSalary()}\n");
        }

        private void OrderByLastNameAndFirstName()
        {
            Console.WriteLine("\nList of all employees ordered by last name and first name\n");
            var employees = _employeesProvider.OrderByLastNameAndFirstName();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        private void OrderBySalary()
        {
            Console.WriteLine("\nList of all employees ordered salary descending\n");
            var employees = _employeesProvider.OrderBySalary();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        private void OrderByStartOfEmployment()
        {
            Console.WriteLine("\nList of all employees ordered by the date of employment\n");
            var employees = _employeesProvider.OrderByStartOfEmployment();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        private void GetEmployeesWhereMinimumSalaryGreaterThen()
        {
            string minSalary = GetUserInput("Please enter the minimum employee salary");
            bool isParsed = int.TryParse(minSalary, out int value);
            if (isParsed)
            {
                Console.WriteLine($"\nList of employees with salary greater then {minSalary}\n");
                var employees = _employeesProvider.EmployeeMinSalary(value);
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                Console.WriteLine("Minimum salary has to be entered as integer number");
            }
        }

        private void GetEmployeesOlderThen()
        {
            string minAge = GetUserInput("Please enter the minimum employee age");
            bool isParsed = int.TryParse(minAge, out int value);
            if (isParsed)
            {
                Console.WriteLine($"\nList of employees older then {minAge}\n");
                var employees = _employeesProvider.EmployeeOlderThen(value);
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                Console.WriteLine("Minimum age has to be entered as integer number");
            }
        }

        private void GetAllEmployeesFromDepartment()
        {
            var department = GetUserInput("Please select the department:\n\tCustomer Service: 1\n\tMechanical Workshop: 2\n\tBody and Paint Workshop: 3\n\tSpare Parts: 4");
            var isParsed = int.TryParse(department, out int departmentValue);
            if (isParsed && departmentValue > 0 && departmentValue <= 4)
            {
                string departmentName = DetermineDepartmentName(departmentValue);
                Console.WriteLine($"\nList of employees from {departmentName}\n");
                var employees = _employeesProvider.EmployeeInDepartment(departmentName);
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                Console.WriteLine("Please enter valid department number");
            }
        }
    }
}
