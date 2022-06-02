using BlazorApp1.Data.DTOs;
using BlazorApp1.Data.Models;

namespace BlazorApp1.Data.Services
{
    public interface ITransportProvider
    {
        Task<List<Transport>> GetAll();
        Task<Transport> GetOne(int id);
        Task<bool> Add(TransportDTO item);
        Task<Transport> Edit(int id, TransportDTO item);
        Task<bool> Remove(int id);
    }
}