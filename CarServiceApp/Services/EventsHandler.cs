using CarServiceApp.Entities;
using CarServiceApp.Repositories;

namespace CarServiceApp.Services
{
    public class EventsHandler : IEventsHandler
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EventsHandler(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void SubscribeToEvents()
        {
            _employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
            _employeeRepository.ItemRemoved += EmployeeRepositoryOnItemRemoved;
        }

        private void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
        {
            _employeeRepository.SaveToAuditFile("Employee Added", e);
        }

        private void EmployeeRepositoryOnItemRemoved(object? sender, Employee e)
        {
            _employeeRepository.SaveToAuditFile("Employee Removed", e);
        }

    }
}
