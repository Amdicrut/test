using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServer.Data.DTOs;
using WebServer.Data.Models;

namespace WebServer.Data.Services
{
    public class TransportService
    {


        private StorageContext _storageContext;



        public TransportService(StorageContext storageContext) => _storageContext = storageContext;
        public async Task<Transport?> AddTransport(TransportDTO transport)
        {
            Transport newTransport = new Transport()
            {
                Type = transport.Type,
                Amount = transport.Amount,

            };
            newTransport.Cargo = await _storageContext.Cargos.FirstOrDefaultAsync(c => c.Id == transport.CargoId);
            var result = _storageContext.Transports.Add(newTransport);
            await _storageContext.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        public async Task<Transport?> GetTransport(int Id)
        {
            var result = await _storageContext.Transports.FirstOrDefaultAsync(transport => transport.Id == Id);
            return await Task.FromResult(result);
        }

        public async Task<List<Transport>> GetTransports()
        {
            var result = await _storageContext.Transports.Include(cl => cl.Cargo).ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<Transport?> UpdateTransport(TransportDTO newTransport)
        {
            var transport = await _storageContext.Transports.FirstOrDefaultAsync(transport => transport.Id == newTransport.Id);
            if (transport != null)
            {
                transport.Type = newTransport.Type;
                transport.Amount = newTransport.Amount;



                var result = _storageContext.Update(transport);
                _storageContext.Entry(transport).State = EntityState.Modified;
                await _storageContext.SaveChangesAsync();
                return await Task.FromResult(result.Entity);
            }

            return null;
        }

        public async Task<bool> DeleteTransport(int Id)
        {
            var transport = await _storageContext.Transports.FirstOrDefaultAsync(transport => transport.Id == Id);

            if (transport != null)
            {
                _storageContext.Transports.Remove(transport);
                await _storageContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
