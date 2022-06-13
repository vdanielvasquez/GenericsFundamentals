namespace WiredBrainCoffee.StackApp.StackSample;

public class SimpleStack<T>
{
    private int _currentIndex = -1;
    private readonly T[] _items;
    private const int _size = 10;

    public SimpleStack() => _items = new T[_size];

    public int Count => _currentIndex + 1;

    public void Push(T item) => _items[++_currentIndex] = item;

    public T Pop() => _items[_currentIndex--];
}