using CarServiceApp.Entities;

namespace CarServiceApp.Repositories
{
    public interface IWriteRepository<in T> where T : class, IEntity
    {
        void Add(T item);
        void Remove(T item);
        void LoadDataFromFile();
        void Save();
        void SaveToFile();
    }
}
