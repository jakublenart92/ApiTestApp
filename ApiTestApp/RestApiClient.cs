using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;



namespace ApiTestApp
{
    public class RestApiClient
    {
        private readonly HttpClient _httpClient;




        public RestApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<ApiUser>> GetUsersAsync()
        {
            var getUsersUrl = "https://jsonplaceholder.typicode.com/todos";
            var response = await _httpClient.GetAsync(getUsersUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Unsuccessful response: {response.StatusCode}");
            }

            var usersJson = await response.Content.ReadAsStringAsync();

            List<ApiUser> users = JsonConvert.DeserializeObject<List<ApiUser>>(usersJson);

            return users;
        }

        public int Test()
        {
            throw new NotImplementedException();
        }
    }






}


