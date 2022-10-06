using CarServiceApp.Entities;
using CarServiceApp.Repositories;

namespace CarServiceApp.Services
{
    public class EventsHandler : IEventsHandler
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Client> _clientRepository;

        public EventsHandler(IRepository<Employee> employeeRepository, IRepository<Client> clientRepository)
        {
            _employeeRepository = employeeRepository;
            _clientRepository = clientRepository;
        }

        public void SubscribeToEvents()
        {
            _employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
            _employeeRepository.ItemRemoved += EmployeeRepositoryOnItemRemoved;
            _clientRepository.ItemAdded += ClientRepositoryOnItemAdded;
        }

        private void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
        {
            _employeeRepository.SaveToAuditFile("Employee Added", e);
        }

        private void EmployeeRepositoryOnItemRemoved(object? sender, Employee e)
        {
            _employeeRepository.SaveToAuditFile("Employee Removed", e);
        }

        private void ClientRepositoryOnItemAdded(object? sender, Client e)
        {
            _clientRepository.SaveToAuditFile("Client Added", e);
        }
    }
}
