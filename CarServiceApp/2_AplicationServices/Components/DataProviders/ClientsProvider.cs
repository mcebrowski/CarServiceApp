using CarServiceApp.Entities;
using CarServiceApp.Repositories;

namespace CarServiceApp.DataProviders
{
    public class ClientsProvider : IClientsProvider
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientsProvider(IRepository<Client> clientRepository) 
        { 
            _clientRepository = clientRepository; 
        }

        List<Client> IClientsProvider.OrderByLastNameAndFirstName()
        {
            var clients = _clientRepository.GetAll();
            return clients.OrderBy(client => client.LastName).ThenBy(client => client.FirstName).ToList();
        }

        List<Client> IClientsProvider.ClientInDepartment(string department)
        {
            var clients = _clientRepository.GetAll();
            return clients.Where(client => client.Department.ToUpper() == department.ToUpper()).ToList();
        }
    }
}
