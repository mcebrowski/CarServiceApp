using CarServiceApp.Data;
using CarServiceApp.Entities;

namespace CarServiceApp.Data.DummyData
{
    public class DummyDataHandlerSql : DummyDataHandler, IDummyDataHandler
    {
        private readonly CarServiceAppDbContext _dbContext;

        public DummyDataHandlerSql(CarServiceAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void AddEmployees()
        {
            if (!_dbContext.Employees.Any())
            {
                var employees = GetEmployees();
                _dbContext.Employees.AddRange(employees);
                _dbContext.SaveChanges();
            }
        }

        public override void AddClients()
        {
            if (!_dbContext.Clients.Any())
            {
                var clients = GetClients();
                _dbContext.Clients.AddRange(clients);
                _dbContext.SaveChanges();
            }
        }
    }
}
