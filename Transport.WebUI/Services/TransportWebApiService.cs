using Microsoft.AspNetCore.Identity.Data;
using System.Net.Http.Json;

namespace Transport.WebUI.Services
{
    public class TransportWebApiService
    {
        private readonly HttpClient _http;

        public TransportWebApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _http.GetAsync(url);

            if(!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"GET Error = {error}");
            }

            return await response.Content.ReadFromJsonAsync<T>()
            ?? throw new Exception("API response null");
        }

        public async Task GetAsync(string url, Guid id)
        {
            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"GET Error = {error}");
            }
        }

        public async Task<TResponse> PostAsync<TRequest,TResponse>(string url , TRequest data)
        {
            var response = await _http.PostAsJsonAsync(url, data);

            if(!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"POST Error = {error}");
            }
            if (typeof(TResponse) == typeof(string))
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return (TResponse)(object)stringResult;
            }
            return await response.Content.ReadFromJsonAsync<TResponse>()
                ?? throw new Exception("API response null");
        }

        public async Task PostAsync<TRequest>(string url, TRequest data)
        {
            var response = await _http.PostAsJsonAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"POST Error = {error}");
            }
        }
    }
}
