using CarServiceApp.Data;

namespace CarServiceApp.Services
{
    public class DataHandlerSql : DataHandler, IDataHandler 
    {
        private readonly CarServiceAppDbContext _dbContext;
        public DataHandlerSql(CarServiceAppDbContext dbContext)
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
    }
}
