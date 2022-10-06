using CarServiceApp.Entities;

namespace CarServiceApp.Data.CsvReader.Extensions
{
    public static class EmployeeExtensions
    {
        public static IEnumerable<Employee> ToEmployee(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(';');

                yield return new Employee
                {
                    FirstName = columns[0],
                    LastName = columns[1],
                    Department = columns[2],
                    Salary = decimal.Parse(columns[3]),
                    DateOfBirth = Convert.ToDateTime(columns[4]),
                    StartOfEmployment = Convert.ToDateTime(columns[5]),
                    IsManager = Convert.ToBoolean(columns[6]),
                };
            }
        }

        public static IEnumerable<Client> ToClient(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(";");

                yield return new Client
                {
                    FirstName = columns[0],
                    LastName = columns[1],
                    Department = columns[2]
                };
            }
        }
    }
}
