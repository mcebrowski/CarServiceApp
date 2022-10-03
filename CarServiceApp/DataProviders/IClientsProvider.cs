using CarServiceApp.Entities;

namespace CarServiceApp.DataProviders
{
    public interface IClientsProvider
    {
        List<Client> OrderByLastNameAndFirstName();

        List<Client> ClientInDepartment(int department);

    }
}
