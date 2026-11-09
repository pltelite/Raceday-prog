using System.Net.Http.Headers;
using System.Text.Json;

namespace RaceDay.Web.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7123/"); // Ensure this matches your API port
            _httpContextAccessor = httpContextAccessor;
        }

        private void AddAuthToken()
        {
            var token = _httpContextAccessor.HttpContext?.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            AddAuthToken();
            var response = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode) return default;
            var content = await response.ContentReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T data)
        {
            AddAuthToken();
            return await _httpClient.PostAsJsonAsync(endpoint, data);
        }
    }
}
