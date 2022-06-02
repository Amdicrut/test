using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServer.Data.DTOs;
using WebServer.Data.Models;

namespace WebServer.Data.Services
{
    public class CustomerService
    {




        private StorageContext _storageContext;


        public CustomerService(StorageContext storageContext) => _storageContext = storageContext;
        public async Task<Customer?> AddCustomer(CustomerDTO customer)
        {
            Customer newCustomer = new Customer()
            {



                Name = customer.Name,
                Surname = customer.Surname,
                Tarriff = customer.Tarriff,
                Phone = customer.Phone,
                Address = customer.Address,

            };

            var result = _storageContext.Customers.Add(newCustomer);
            await _storageContext.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        public async Task<Customer?> GetCustomer(int Id)
        {
            var result = await _storageContext.Customers.FirstOrDefaultAsync(customer => customer.Id == Id);
            return await Task.FromResult(result);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var result = await _storageContext.Customers.Include(cl => cl.Cargos).ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<Customer?> UpdateCustomer(int id, CustomerDTO newCustomer)
        {
            var customer = await _storageContext.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
            if (customer != null)
            {
                customer.Name = newCustomer.Name;
                customer.Surname = newCustomer.Surname;
                customer.Tarriff = newCustomer.Tarriff;
                customer.Phone = newCustomer.Phone;
                customer.Address = newCustomer.Address;

                var result = _storageContext.Update(customer);
                _storageContext.Entry(customer).State = EntityState.Modified;
                await _storageContext.SaveChangesAsync();
                return await Task.FromResult(result.Entity);
            }

            return null;
        }

        public async Task<bool> DeleteCustomer(int Id)
        {
            var customer = await _storageContext.Customers.FirstOrDefaultAsync(customer => customer.Id == Id);

            if (customer != null)
            {
                _storageContext.Customers.Remove(customer);
                await _storageContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
