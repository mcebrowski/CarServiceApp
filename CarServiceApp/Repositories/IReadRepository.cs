using CarServiceApp.Entities;

namespace CarServiceApp.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();

        //void LoadDataFromFile();

        T GetById(int id);
    }
}
