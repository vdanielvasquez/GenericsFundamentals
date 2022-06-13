namespace WiredBrainCoffee.StackApp.StackSample;

public class SimpleStackDouble
{
    private readonly double[] _items;
    private int _currentIndex = -1;

    public SimpleStackDouble() => _items = new double[10];

    public int Count() => _currentIndex + 1;
    
    public void Push(double item) =>_items[++_currentIndex] = item;

    public double Pop() => _items[_currentIndex--];

}