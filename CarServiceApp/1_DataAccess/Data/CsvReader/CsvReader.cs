using CarServiceApp.Data.CsvReader.Extensions;
using CarServiceApp.Entities;

namespace CarServiceApp.Data.CsvReader
{
    public class CsvReader : ICsvReader
    {
        public List<Employee> ProcessEmployees(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Employee>();
            }

            var employees = File.ReadAllLines(filePath)
                .Skip(1)
                .Where(x => x.Length > 1)
                .ToEmployee();

            return employees.ToList();
        }

        public List<Client> ProcessClients(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Client>();
            }

            var clients = File.ReadAllLines(filePath)
                .Skip(1)
                .Where(x => x.Length > 1)
                .ToClient();

            return clients.ToList();
        }
    }
}
