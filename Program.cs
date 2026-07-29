using DelegateLambdaEventDemo.Model;

namespace DelegateLambdaEventDemo;

// Delegate - Method can be strored inside the varible and the type of that varible called delegate
// Custome - Delegation

// public delegate void Notification(string message);

public class Program
{
    public static void Main(String[] args)
    {
        //Multicast Delegate: One delegate can store multiple methods.
        // Notification notification = SendSms;
        // notification += SendSms;
        // notification += SendLog;

        // Action<T> - Default return type void , Predicate<T> - Default return type boolean , Fun<int,int> - last as return type parameter 
        Action<string> notification = SendEmail;


        // lambda function added...
        notification += message => Console.WriteLine($"Whatchapp Message :{message}");

        // notification("Farm created");


        List<Farm> farms = new() {
            new Farm
            {
                Name="Green Farm",
                IsOrganic=true
            },

            new Farm
            {
                Name="Modern Farm",
                IsOrganic=false
            },

            new Farm
            {
                Name="Natural Farm",
                IsOrganic=true
            }
        };

        // Here Where is used the lambda function
        // Internally Where used the Fun<T,bool> to store the varible for the passing argument
        var organicFarms = farms.Where(f => f.IsOrganic);
        foreach (var farm in organicFarms){
            Console.WriteLine(farm.Name);
        }

    }

    static void SendEmail(string message)
    {
        Console.WriteLine($"Email:{message}");
    }

    static void SendSms(string message)
    {
        Console.WriteLine($"SMS:{message}");
    }

    static void SendLog(string message)
    {
        Console.WriteLine($"Log:{message}");
    }

    // static void whatchaap(string message)
    // {
    //     Console.WriteLine($"Whatchapp Message :{message}");
    // }
}