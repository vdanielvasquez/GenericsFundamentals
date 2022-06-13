using WiredBrainCoffee.StackApp.Models;

namespace WiredBrainCoffee.StackApp.Repository;

public static class Usage
{
    public static void Run()
    {
        ManageEmployees();
        ManageOrganizations();
        Console.ReadLine();
    }
    
    public static void ManageEmployees()
    {
        var heroesRepo = new EmployeeRepository();
        heroesRepo.Add(new Employee {FirstName = "Bruce"});
        heroesRepo.Add(new Employee {FirstName = "Dick"});
        heroesRepo.Add(new Employee {FirstName = "Alfred"});
        heroesRepo.Save();
    
        var foesRepo = new GenericRepositoryWithRemove<Employee>();
        var oswald = new Employee {FirstName = "Oswald"};
        foesRepo.Add(new Employee {FirstName = "Edward"});
        foesRepo.Add(oswald);
        foesRepo.Add(new Employee {FirstName = "Harvey"});
        foesRepo.Save();
    
        foesRepo.Remove(oswald);
        foesRepo.Save();


        var sidekicks = new GenericRepository<Employee>();
        var lois = new Employee {FirstName = "Lois"};
    
    
        sidekicks.Add(new Employee{FirstName = "Dick"});
        sidekicks.Add(lois);
        sidekicks.Add(new Employee{FirstName = "Bart"});
        sidekicks.Save();

        var found = sidekicks.GetById(2);

        sidekicks.Remove(lois);
        sidekicks.Add(new Employee{FirstName = "Ted"});
        sidekicks.Save();
        //found = sidekicks.GetById(2); will fail

    }

    public static void ManageOrganizations()
    {
        var organizationRepo = new GenericRepository<Organization>();
        organizationRepo.Add(new Organization {Name = "Wayne Enterprises"});
        organizationRepo.Add(new Organization {Name = "Lexcorp"});
        organizationRepo.Add(new Organization {Name = "Kord Industries"});
        organizationRepo.Save();
    }
}