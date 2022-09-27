using CarServiceApp.Entities;

namespace CarServiceApp.DataProviders.Extensions
{
    public static class EmployeesHelper
    {
        public static IEnumerable<Employee> ByLastName(this IEnumerable<Employee> query, string lastName)
        {
            return query.Where(x => x.LastName == lastName);
        }
    }
}
