using AdoLearn;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Data.SqlClient;

public class Progrma
{
   
    public static void Main(String[] args)
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=multi_universities; Trusted_connection=True; TrustServerCertificate=True;";
        UniversityService _uniService = new UniversityService(connectionString);
        

        switch (5)
        {
            case 1:
                _uniService.GetAllUniversities();
                break;
            
            case 2:

                //Console.WriteLine("Enter University details : ");
                //Console.Write("University");
                //string? uni_name = Console.ReadLine();
                //string? city = Console.ReadLine();
                //string? state = Console.ReadLine();
                //int? established_at = Convert.ToInt32(Console.ReadLine());

                //string insert_university = "INSERT INTO universities(uni_name,city,state,established_at) VALUES('Marvadi University','Nadiyad','Mumbai',2008);";
                //("SMSU", "Bombay", "Maharashtra", 2000);

                _uniService.AddUniversities("SMSU", "Bombay", "Maharashtra", 2000);

                break;

            case 3:
                _uniService.GetStudentdetails();
                break;

            case 4:
                _uniService.GetUniversitiesByAdpter(connectionString);
                break;

            case 5:
                _uniService.GetUniversitiesByAdpter(connectionString);
                break;
        }
        

    }

}