using WiredBrainCoffee.StackApp.Models;

namespace WiredBrainCoffee.StackApp.Repository;

public class EmployeeRepository
{
    private readonly List<Employee> _employees = new();
    
    public void Add(Employee employee)
    {
        _employees.Add(employee);
    }

    public void Save()
    {
        foreach (var employee in _employees)
        {
            Console.WriteLine($"{employee}");
        }

        Console.WriteLine("-----------------------------");
    }
}