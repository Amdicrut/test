using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

using BlazorApp1.Data.Services;
using BlazorApp1.Data.Models;
using BlazorApp1.Data.DTOs;

namespace BlazorApp1.Data.Services
{
    public class TransportsProvider : ITransportProvider
    {
        private HttpClient _client;
        public TransportsProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Transport>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<Transport>>("/api/transport");
        }
        public async Task<Transport> GetOne(int id)
        {
            return await _client.GetFromJsonAsync<Transport>($"/api/transport/{id}");
        }
        public async Task<bool> Add(TransportDTO item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/transport", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }
        public async Task<Transport> Edit(int id, TransportDTO item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync($"/api/transport/{id}", httpContent);
            Transport transport =
            JsonConvert.DeserializeObject<Transport>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(transport);
        }
        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/transport/{id}");
            return await Task.FromResult(delete.IsSuccessStatusCode);
        }
    }
}
