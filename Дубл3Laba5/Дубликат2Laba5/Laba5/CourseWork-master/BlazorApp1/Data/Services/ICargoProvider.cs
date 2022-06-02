using BlazorApp1.Data.Models;

namespace BlazorApp1.Data.Services
{
    public interface ICargoProvider
    {
        Task<List<Cargo>> GetAll();
        Task<Cargo> GetOne(int id);
        Task<bool> Add(Cargo item);
        Task<Cargo> Edit(Cargo item);
        Task<bool> Remove(int id);
    }
}
