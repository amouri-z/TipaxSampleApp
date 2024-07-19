using Microsoft.EntityFrameworkCore;
using TipaxSampleApp.Models;

namespace TipaxSampleApp.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<Customer>> GetAllCustomersAsync();

        Task<Customer> GetCustomerByIdAsync(int id);

        Task AddCustomerAsync(Customer customer);

        Task UpdateCustomerAsync(Customer customer);

        Task DeleteCustomerAsync(int id);

        Task<bool> EmailExists(int? id, string email);

        Task<bool> CustomerExists(int? id, string firstName, string lastName, long phoneNumber);

        Task<Customer> GetCustomerAsync(string firstName, string lastName, long phoneNumber);
    }
}