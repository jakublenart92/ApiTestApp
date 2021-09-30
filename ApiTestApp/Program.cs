using System;
using System.Threading.Tasks;

namespace ApiTestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var apiClient = new RestApiClient();

            var users = await apiClient.GetUsersAsync();

            Console.WriteLine(users);

            Console.WriteLine();
            Console.WriteLine("Press Any Key to kill the app...");
            Console.ReadLine();
        }
    }
}
