using System;
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

        public async Task<string> GetUsersAsync()
        {
            var getUsersUrl = "https://gorest.co.in/public/v1/users";
            var response = await _httpClient.GetAsync(getUsersUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Unsuccessful response: {response.StatusCode}");
            }

            var usersJson = await response.Content.ReadAsStringAsync();

            return usersJson;
        }
    }
}