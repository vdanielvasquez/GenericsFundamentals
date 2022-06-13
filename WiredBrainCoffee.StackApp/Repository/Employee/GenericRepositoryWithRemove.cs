namespace WiredBrainCoffee.StackApp.Repository;

public class GenericRepositoryWithRemove<T> : GenericRepositoryWithInheritance<T>
{
    public void Remove(T item)
    {
        _list.Remove(item);
    }
}