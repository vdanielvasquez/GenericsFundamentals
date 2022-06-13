namespace WiredBrainCoffee.StackApp.Repository;

public class GenericRepositoryWithInheritance<T>
{
    protected readonly List<T> _list = new();
    
    public void Add(T item)
    {
        _list.Add(item);
    }

    public void Save()
    {
        foreach (var item in _list)
        {
            Console.WriteLine($"{item}");
        }
        Console.WriteLine("------------------------");
    }

}