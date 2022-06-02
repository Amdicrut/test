using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServer.Data.DTOs;
using WebServer.Data.Models;

namespace WebServer.Data.Services
{
    public class CargoService
    {


        private StorageContext _storageContext;



        public CargoService(StorageContext storageContext) => _storageContext = storageContext;
        public async Task<Cargo?> AddCargo(CargoDTO cargo)
        {
            Cargo newCargo = new Cargo()
            {

                Amount = cargo.Amount,
                Type = cargo.Type,
                Terms = cargo.Terms,
                Expenses = cargo.Expenses,

            };
            newCargo.Customer = await _storageContext.Customers.FirstOrDefaultAsync(c => c.Id == cargo.CustomerId);
            var result = _storageContext.Cargos.Add(newCargo);
            await _storageContext.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        public async Task<Cargo?> GetCargo(int Id)
        {
            var result = await _storageContext.Cargos.FirstOrDefaultAsync(cargo => cargo.Id == Id);
            return await Task.FromResult(result);
        }

        public async Task<List<Cargo>> GetCargos()
        {
            var result = await _storageContext.Cargos.Include(cl => cl.Transports).ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<Cargo?> UpdateCargo(CargoDTO newCargo)
        {
            var cargo = await _storageContext.Cargos.FirstOrDefaultAsync(cargo => cargo.Id == newCargo.Id);
            if (cargo != null)
            {
                cargo.Amount = newCargo.Amount;
                cargo.Type = newCargo.Type;
                cargo.Terms = newCargo.Terms;
                cargo.Expenses = newCargo.Expenses;


                var result = _storageContext.Update(cargo);
                _storageContext.Entry(cargo).State = EntityState.Modified;
                await _storageContext.SaveChangesAsync();
                return await Task.FromResult(result.Entity);
            }

            return null;
        }

        public async Task<bool> DeleteCargo(int Id)
        {
            var cargo = await _storageContext.Cargos.FirstOrDefaultAsync(cargo => cargo.Id == Id);

            if (cargo != null)
            {
                _storageContext.Cargos.Remove(cargo);
                await _storageContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
