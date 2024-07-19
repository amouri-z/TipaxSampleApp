using AutoMapper;
using FluentValidation;
using TipaxSampleApp.Models;
using TipaxSampleApp.Repositories.Interfaces;
using TipaxSampleApp.Services.Interfaces;
using TipaxSampleApp.Validators.Interfaces;
using TipaxSampleApp.ViewModels;

namespace TipaxSampleApp.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerServiceValidator _customerValidator;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, ICustomerServiceValidator customerValidator)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerValidator = customerValidator;
        }

        public async Task<IReadOnlyList<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await GetCustomer(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> AddCustomerAsync(CustomerDto customerDto)
        {
            await _customerValidator.ValidateAndThrowAsync(customerDto);
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.AddCustomerAsync(customer);
            var insertedCustomer = await _customerRepository.GetCustomerAsync(customer.FirstName, customer.LastName, customer.PhoneNumber);
            return _mapper.Map<CustomerDto>(insertedCustomer);
        }

        public async Task UpdateCustomerAsync(CustomerDto customerDto)
        {
            await _customerValidator.ValidateAndThrowAsync(customerDto);
            var customer = await GetCustomer(customerDto.Id);
            _mapper.Map(customerDto, customer);
            await _customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }

        private async Task<Customer> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            return customer == null ? throw new Exception("مشتری یافت نشد.") : customer;
        }
    }
}