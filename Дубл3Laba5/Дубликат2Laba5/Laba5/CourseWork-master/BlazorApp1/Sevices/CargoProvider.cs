using BlazorApp1.Data.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BlazorApp1.Sevices
{
    public class CargoProvider : ICargoProvider
    {
        private readonly HttpClient _httpclient;
        public CargoProvider(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }

        public async Task<List<Cargo>?> GetAll()
        {
            return await _httpclient.GetFromJsonAsync<List<Cargo>>("/api/Cargo");
        }

        public async Task<List<string>?> GetAllNames()
        {
            return await _httpclient.GetFromJsonAsync<List<string>>("/api/Cargo/Names");
        }

        public async Task<Cargo?> GetOne(int id)
        {
            return await _httpclient.GetFromJsonAsync<Cargo>($"/api/Cargo/{id}");
        }

        public async Task<bool> Add(Cargo Cargo)
        {
            string data = JsonConvert.SerializeObject(Cargo);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var responce = await _httpclient.PostAsync("/api/Cargo", httpContent);

            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Cargo?> Edit(Cargo product)
        {
            string data = JsonConvert.SerializeObject(product);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpclient.PutAsync("/api/Cargo", httpContent);

            Cargo? editCargo = JsonConvert.DeserializeObject<Cargo>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(editCargo);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _httpclient.DeleteAsync($"/api/Cargo/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }
    }
}
