using DelegateLambdaEventDemo.Model;

namespace DelegateLambdaEventDemo.Services;

internal class FarmService
{
    // Event -handler
    // event - Its look like the delegate but its cannot be updated its only subscibe and disubscribe and Invoke that just like the ompletion or start the events;
    // Delagate can be assign the new value directlty like : delegate Action<string> FarmCreated; FarmCreated farms= SendMail; farms=null;
    public event Action<string>? FarmCreated;

    public void CreateFarm(string farmName)
    {

        Console.WriteLine($"Creating {farmName}");

        FarmCreated?.Invoke($"Congratulations!!!...{farmName}");
    }
}