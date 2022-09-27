using CarServiceApp.Entities;
using CarServiceApp.Repositories;

namespace CarServiceApp.DataProviders
{
    public class EmployeesProvider : IEmployeesProvider
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeesProvider(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> EmployeeInDepartment(int department)
        {
            var employees = _employeeRepository.GetAll();
            string? departmentName = Enum.GetName(typeof(Department),department);
    
            return employees.Where(employee => employee.Department.ToString().Contains(departmentName)).ToList();          
        }

        public List<Employee> EmployeeMinSalary(decimal minSalary)
        {
            var employees = _employeeRepository.GetAll();
            return employees.OrderBy(employee => employee.Salary).Where(employee => employee.Salary >= minSalary).ToList();
        }

        public List<Employee> EmployeeOlderThen(int age)
        {
            var employees = _employeeRepository.GetAll();
            return employees.OrderBy(employee => employee.DateOfBirth).Where(employee => DateTime.Now.Year - employee.DateOfBirth.Year >= age).ToList();
        }

        public decimal GetMinimumSalary()
        {
            var employees = _employeeRepository.GetAll();
            return employees.Select(employee => employee.Salary).Min();
        }

        public List<Department> GetUniqueDepartment()
        {
            var employees = _employeeRepository.GetAll();
            var departments = employees.Select(employee => employee.Department).Distinct().ToList();
            return departments;
        }

        public List<Employee> OrderByLastNameAndFirstName()
        {
            var employees = _employeeRepository.GetAll();
            return employees.OrderBy(employee => employee.LastName).ThenBy(employee => employee.FirstName).ToList();
        }

        public List<Employee> OrderBySalary()
        {
            var employees = _employeeRepository.GetAll();
            return employees.OrderByDescending(employee => employee.Salary).ToList();
        }

        public List<Employee> OrderByStartOfEmployment()
        {
            var employees = _employeeRepository.GetAll();
            return employees.OrderBy(employee => employee.StartOfEmployment).ToList();
        }
          
        // Below not used in app :)
        public Employee? SingleOrDefaultById(int id)
        {
            var employees = _employeeRepository.GetAll();
            return employees.SingleOrDefault(employee => employee.Id == id);
        }

        public List<Employee> SkipEmployees(int howMany)
        {
            var employees = _employeeRepository.GetAll();
            return employees.OrderBy(employee => employee.LastName).Skip(howMany).ToList();
        }

        public List<Employee> TakeEmployees(int howMany)
        {
            var employees = _employeeRepository.GetAll();
            return employees.OrderBy(employee => employee.LastName).Take(howMany).ToList();
        }

        public List<Employee> TakeEmployees(Range range)
        {
            var employees = _employeeRepository.GetAll();
            return employees.OrderBy(employee => employee.LastName).Take(range).ToList();
        }

    }
}
