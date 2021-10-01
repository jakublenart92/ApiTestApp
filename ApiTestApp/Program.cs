using System;
using System.Threading.Tasks;
using MongoDB.Driver;



namespace ApiTestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var apiClient = new RestApiClient();
            var users = await apiClient.GetUsersAsync();

            var dbConnection = MongoClientSettings.FromConnectionString("mongodb+srv://Admin_user:k9XHwvycQK9RPf9U@cluster0.gh1xc.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var client = new MongoClient(dbConnection);

            var database = client.GetDatabase("myFirstDatabase");

            var collection = database.GetCollection<MongoDefaultObject>("Users");

            //var users = await collection.Find(Builders<User>.Filter.Empty).ToListAsync();






            //documentInput.name = "Patrycja";
            //documentInput.isHuman = false;








            //onsole.WriteLine(dbConnection);

            foreach (var particularUser in users)
            {
                var documentInput = new MongoDefaultObject();
                documentInput.UserId = particularUser.UserId;
                documentInput.title = particularUser.title;
                documentInput.apiId = particularUser.id;
                documentInput.completed = particularUser.completed;

                Console.WriteLine(particularUser.title);
                await collection.InsertOneAsync(documentInput);
            }






            //Console.WriteLine();
            //Console.WriteLine("Press Any Key to kill the app...");
            //Console.ReadLine();
        }
    }

}


