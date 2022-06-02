using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BlazorApp1.Data.Models;
using BlazorApp1.Data.Services;
using BlazorApp1.Data.DTOs;


namespace BlazorApp1.Data.Services
{
    public class CustomersProvider : ICustomerProvider
    {
        private HttpClient _client;
        public CustomersProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<Customer>>("/api/customer");
        }
        public async Task<Customer> GetOne(int id)
        {
            return await _client.GetFromJsonAsync<Customer>($"/api/customer/{id}");
        }
        public async Task<bool> Add(CustomerDTO item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/customer", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }
        public async Task<Customer> Edit(int id, CustomerDTO item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync($"/api/customer/{id}", httpContent);
            Customer customer = JsonConvert.DeserializeObject<Customer>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(customer);
        }
        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/customer/{id}");
            return await Task.FromResult(delete.IsSuccessStatusCode);
        }
    }
}
