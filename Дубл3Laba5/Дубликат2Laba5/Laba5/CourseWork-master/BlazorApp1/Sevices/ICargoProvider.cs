using BlazorApp1.Data.Models;

namespace BlazorApp1.Sevices
{
    public interface ICargoProvider
    {
        Task<List<Cargo>> GetAll();
        Task<List<string>> GetAllNames();
        Task<Cargo> GetOne(int id);
        Task<bool> Add(Cargo Cargo);
        Task<Cargo> Edit(Cargo Cargo);
        Task<bool> Remove(int id);
    }
}
