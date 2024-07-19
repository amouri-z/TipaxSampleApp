using Microsoft.EntityFrameworkCore;
using TipaxSampleApp.Configurations;
using TipaxSampleApp.Models;
using TipaxSampleApp.Repositories.Interfaces;

namespace TipaxSampleApp.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TipaxSampleAppDbContext _context;

        public CustomerRepository(TipaxSampleAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> EmailExists(int? id, string email)
        {
            return id.HasValue ?
                await _context.Customers.AnyAsync(c => c.Id != id && c.Email == email) :
                await _context.Customers.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> CustomerExists(int? id, string firstName, string lastName, long phoneNumber)
        {
            return id.HasValue ?
                await _context.Customers.AnyAsync(c => c.Id != id && c.FirstName == firstName && c.LastName == lastName && c.PhoneNumber == phoneNumber) :
                await _context.Customers.AnyAsync(c => c.FirstName == firstName && c.LastName == lastName && c.PhoneNumber == phoneNumber);
        }

        public async Task<Customer> GetCustomerAsync(string firstName, string lastName, long phoneNumber)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.FirstName == firstName && c.LastName == lastName && c.PhoneNumber == phoneNumber);
        }
    }
}