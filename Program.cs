using DelegateLambdaEventDemo.Model;
using DelegateLambdaEventDemo.Services;

namespace DelegateLambdaEventDemo;


public class Program
{
    public static void Main(String[] args)
    {

        List<Farm> farms = [
            new Farm{
                Name="Green Farm",
                IsOrganic=true
            },
            new Farm{
                Name="Modern Farm",
                IsOrganic=false
            },
            new Farm{
                Name="Natural Farm",
                IsOrganic=true
            }
        ];

        foreach (var farm in farms)
        {
            // Console.WriteLine(farm.ToString());
            farm.farmDetails();
        }

    }
}