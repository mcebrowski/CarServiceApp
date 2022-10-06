using CarServiceApp.Entities;

namespace CarServiceApp.Repositories
{
    public interface IWriteRepository<in T> where T : class, IEntity
    {
        void Add(T item);
        void Remove(T item);
        void Save(string description);
        void SaveToAuditFile(string description, T e);
    }
}
