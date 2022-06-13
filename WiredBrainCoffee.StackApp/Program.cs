using WiredBrainCoffee.StackApp.Data;
using WiredBrainCoffee.StackApp.Extensions;
using WiredBrainCoffee.StackApp.Models;
using WiredBrainCoffee.StackApp.Repository;

Action<Employee> itemAdded = EmployeeAdded;

IRepository<Employee> sidekicks = new SqlRepository<Employee>(new StorageAppDbContext(), itemAdded);

Action<Manager> managerAdded = itemAdded;

AddEmployees(sidekicks);
AddManagers(sidekicks);

//IWriteRepository<Manager> bosses = new SqlRepository<Employee>(new StorageAppDbContext());
//AddManagers(bosses);
WriteAllToConsole(sidekicks);

var found = sidekicks.GetById(2);
Console.WriteLine($"Found: {found}");
sidekicks.Save();

IRepository<Organization> organizationRepo = new ListRepository<Organization>();
AddOrganization(organizationRepo);
WriteAllToConsole(organizationRepo);

static void EmployeeAdded(Employee employee)
{
    Console.WriteLine($"Added ===> {employee}");
}

static void AddEmployees(IRepository<Employee> repo)
{
    var employees = new[]
    {
        new Employee {FirstName = "Dick"},
        new Employee {FirstName = "Lois"},
        new Employee {FirstName = "Bart"},
        new Employee{FirstName = "Ted"}
    };
    AddBatch(repo, employees);
}

static void AddManagers(IWriteRepository<Manager> managerRepo)
{
    var luciusManager = new Manager() {FirstName = "Lucius"};
    var luciusManagerCopy = luciusManager.Copy<Manager>();
    managerRepo.Add(luciusManager);
    
    if (luciusManagerCopy is not null)
    {
        luciusManagerCopy.FirstName += "_copy";
        managerRepo.Add(luciusManagerCopy);
    }

    managerRepo.Add(new Manager{FirstName = "Gordon"});
    managerRepo.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    foreach (var item in repository.GetAll())
    {
        Console.WriteLine(item.ToString());
    }
}

static void AddOrganization(IRepository<Organization> repo)
{
    var organizations = new[]
    {
        new Organization {Name = "Wayne Enterprises"},
        new Organization {Name = "Lexcorp"},
        new Organization {Name = "Kord Industries"}
    };
    AddBatch(repo, organizations);
}

static void AddBatch<T> (IRepository<T> repo, IEnumerable<T> items) where T: IEntity
{
    foreach (var item in items)
    {
        repo.Add(item);
    }
    repo.Save();
}