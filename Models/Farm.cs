
namespace DelegateLambdaEventDemo.Model;

public class Farm
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsOrganic { get; set; }

    public void farmDetails()
    {
        Console.WriteLine($"{Id}\t{Name}\t{IsOrganic}");
    }
}