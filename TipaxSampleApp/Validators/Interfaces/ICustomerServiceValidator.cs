using FluentValidation;
using TipaxSampleApp.ViewModels;

namespace TipaxSampleApp.Validators.Interfaces
{
    public interface ICustomerServiceValidator : IValidator<CustomerDto>
    {
    }
}