using CarServiceApp.Entities;

namespace CarServiceApp.DataProviders
{
    public interface IEmployeesProvider
    {
        List<string> GetUniqueDepartment();
        decimal GetMinimumSalary();
        List<Employee> OrderBySalary();
        List<Employee> OrderByStartOfEmployment();
        List<Employee> OrderByLastNameAndFirstName();
        List<Employee> EmployeeMinSalary(decimal minSalary);
        List<Employee> EmployeeOlderThen(int age);
        List<Employee> EmployeeInDepartment(string department);

        // Below not used in app
        Employee? SingleOrDefaultById(int id);
        List<Employee> TakeEmployees(int howMany);
        List<Employee> TakeEmployees(Range range);
        List<Employee> SkipEmployees(int howMany);
    }
}
