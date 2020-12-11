using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bertoni_Examen.Infrastructure.NetWork
{
    public class ClientWrapper : IClientWrapper
    { 
        private readonly HttpClient _httpClient;
        public ClientWrapper(HttpClient httpClient) => _httpClient = httpClient;
        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }
    }
}
