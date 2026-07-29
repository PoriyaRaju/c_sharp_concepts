using DelegateLambdaEventDemo.Model;

namespace DelegateLambdaEventDemo.Services;

internal class FarmService
{
    public event Action<string>? FarmCreated;

    public void CreateFarm(string farmName)
    {

        Console.WriteLine($"Creating {farmName}");

        FarmCreated?.Invoke($"Congratulations!!!...{farmName}");
    }
}