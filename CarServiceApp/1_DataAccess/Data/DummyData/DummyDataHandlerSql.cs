using CarServiceApp.Data.CsvReader;

namespace CarServiceApp.Data.DummyData
{
    public class DummyDataHandlerSql : IDummyDataHandler
    {
        private readonly CarServiceAppDbContext _dbContext;
        private readonly ICsvReader _csvReader;

        public DummyDataHandlerSql(CarServiceAppDbContext dbContext, ICsvReader csvReader)
        {
            _dbContext = dbContext;
            _csvReader = csvReader;
        }

        public void AddEmployees()
        {
            if (!_dbContext.Employees.Any())
            {
                var employees = _csvReader.ProcessEmployees(@"1_DataAccess\Resources\Files\employees.csv");
                _dbContext.Employees.AddRange(employees);
                _dbContext.SaveChanges();
            }
        }

        public void AddClients()
        {
            if (!_dbContext.Clients.Any())
            {
                var clients = _csvReader.ProcessClients(@"1_DataAccess\Resources\Files\clients.csv");
                _dbContext.Clients.AddRange(clients);
                _dbContext.SaveChanges();
            }
        }
    }
}
