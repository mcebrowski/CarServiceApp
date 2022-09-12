using CarServiceApp.Entities;

namespace CarServiceApp.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
    }
}
