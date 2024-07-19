using FluentValidation;
using TipaxSampleApp.Repositories.Interfaces;
using TipaxSampleApp.Validators.Interfaces;
using TipaxSampleApp.ViewModels;

namespace TipaxSampleApp.Validators.Implementations
{
    public sealed class CustomerServiceValidator : AbstractValidator<CustomerDto>, ICustomerServiceValidator
    {
        private readonly ICustomerRepository _repository;

        public CustomerServiceValidator(ICustomerRepository repository)
        {
            _repository = repository;

            RuleFor(customer => customer).MustAsync(EmailExists).WithMessage("ایمیل قبلا در سیستم ثبت شده است.");
            RuleFor(customer => customer).MustAsync(CustomerExists).WithMessage("اطلاعات مشتری قبلا در سیستم ثبت شده است.");
        }

        private async Task<bool> EmailExists(CustomerDto customerDto, CancellationToken cancellationToken)
        {
            return await _repository.EmailExists(customerDto.Id, customerDto.Email);
        }

        private async Task<bool> CustomerExists(CustomerDto customerDto, CancellationToken cancellationToken)
        {
            return await _repository.CustomerExists(customerDto.Id, customerDto.FirstName, customerDto.LastName, customerDto.PhoneNumber);
        }
    }
}