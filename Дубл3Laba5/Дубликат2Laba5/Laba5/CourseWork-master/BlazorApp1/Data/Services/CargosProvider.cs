using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BlazorApp1.Data.Models;
using BlazorApp1.Data.Services;


namespace BlazorApp1.Data.Services
{
    public class CargosProvider : ICargoProvider
    {
        private HttpClient _client;
        public CargosProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Cargo>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<Cargo>>("/api/cargo");
        }
        public async Task<Cargo> GetOne(int id)
        {
            return await _client.GetFromJsonAsync<Cargo>($"/api/cargo/{id}");
        }
        public async Task<bool> Add(Cargo item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/author", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }
        public async Task<Cargo> Edit(Cargo item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync($"/api/cargo", httpContent);
            Cargo cargo =
            JsonConvert.DeserializeObject<Cargo>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(cargo);
        }
        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/cargo/{id}");
            return await Task.FromResult(delete.IsSuccessStatusCode);
        }


    }
}
