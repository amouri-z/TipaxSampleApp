using TipaxSampleApp.ViewModels;

namespace TipaxSampleApp.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IReadOnlyList<CustomerDto>> GetAllCustomersAsync();

        Task<CustomerDto> GetCustomerByIdAsync(int id);

        Task<CustomerDto> AddCustomerAsync(CustomerDto customerDto);

        Task UpdateCustomerAsync(CustomerDto customerDto);

        Task DeleteCustomerAsync(int id);
    }
}