using DelegateLambdaEventDemo.Model;

namespace DelegateLambdaEventDemo.Services;

internal class FarmService
{
    public void CreateFarm(string farmName)
    {
        Console.WriteLine($"Creating {farmName}");
    }
}