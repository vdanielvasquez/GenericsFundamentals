using WiredBrainCoffee.StackApp.Models;

namespace WiredBrainCoffee.StackApp.Repository;

public interface IWriteRepository<in T> //contravariant type parameter
{
    void Add(T item);
    void Remove(T item);
    void Save();
}

public interface IReadRepository<out T> //covariant type parameter
{
    IEnumerable<T> GetAll();
    T GetById(int id);
}

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : IEntity
{
}
