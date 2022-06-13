using WiredBrainCoffee.StackApp.Models;

namespace WiredBrainCoffee.StackApp.Repository;

public class ListRepository<T> : IRepository<T> where  T : IEntity
{
    private readonly List<T> _list = new();

    public IEnumerable<T> GetAll()
    {
        return _list.ToList();
    }

    public T GetById(int id)
    {
        var item =_list.Single(x => x.Id == id);
        Console.WriteLine($"found: {item}");
        return item;
    }

    public void Add(T item)
    {
        item.Id = _list.Count + 1;
        _list.Add(item);
    }
    
    public void Remove(T item)
    {
        _list.Remove(item);
    }

    public void Save()
    {
        //Everything is saved in the List<T>
    }
}