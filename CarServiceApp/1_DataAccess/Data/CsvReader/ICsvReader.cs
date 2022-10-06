using CarServiceApp.Entities;

namespace CarServiceApp.Data.CsvReader
{
        public interface ICsvReader
    {
        List<Employee> ProcessEmployees(string filePath);

        List<Client> ProcessClients(string filePath);
    }
}
