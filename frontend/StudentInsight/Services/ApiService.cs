using System.Net.Http;
using System.Net.Http.Json;

namespace StudentInsight.Services
{
    public class ApiService
    {
        private readonly HttpClient httpClient;

        public ApiService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5011/api/") // The API
            };
        }

        // POST
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var response = await httpClient.PostAsJsonAsync(endpoint, data);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        // GET
        public async Task<TResponse> GetAsync<TResponse>(string endpoint)
        {
            return await httpClient.GetFromJsonAsync<TResponse>(endpoint);
        }
    }
}