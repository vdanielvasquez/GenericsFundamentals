namespace WiredBrainCoffee.StackApp.StackSample;

public static class Usage
{
    static void Run()
    {
        StackDoubles();
        StackStrings();
        Console.ReadLine();
    }

    static void StackDoubles()
    {
        var stack = new SimpleStack<double>();
        stack.Push(1.2);
        stack.Push(2.8);
        stack.Push(3.0);

        double sum = 0.0;
        while (stack.Count > 0)
        {
            double item = stack.Pop();
            sum += item;
            Console.WriteLine($"Item: {item}");
        }

        Console.WriteLine($"Sum: {sum}");
    }
    static void StackStrings()
    {
        var stack = new Stack<string>(); //microsoft
        stack.Push("Wired Brain Coffee");
        stack.Push("Pluralsight");

        while (stack.Count > 0)
        {
            Console.WriteLine($"{stack.Pop()}");
        }
    }
}