using FluentValidation;
using TipaxSampleApp.Validators.Interfaces;
using TipaxSampleApp.ViewModels;

namespace TipaxSampleApp.Validators.Implementations
{
    public class CustomerModelValidator : AbstractValidator<CustomerBindingModel>, ICustomerModelValidator
    {
        public CustomerModelValidator()
        {
            // Default RuleSet
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("لطفا نام را وارد کنید.");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("لطفا نام خانوادگی را وارد کنید.");
            RuleFor(c => c.DateOfBirth).NotEmpty().WithMessage("لطفا تاریخ تولد را وارد کنید.");
            RuleFor(c => c.PhoneNumber).Must(phoneNumber => phoneNumber.ToString().Length == 10)
                .WithMessage("شماره تماس وارد شده معتبر نمی باشد.");
            RuleFor(c => c.Email).EmailAddress().WithMessage("ایمیل وارد شده معتبر نمی باشد.");
            RuleFor(c => c.BankAccountNumber).NotEmpty().WithMessage("لطفا شماره حساب بانکی را وارد کنید.");

            // RuleSet for updating a customer
            RuleSet("Update", () =>
            {
                RuleFor(c => c.Id).Must(id => id.HasValue && id != 0).WithMessage("شناسه مشتری نامعتبر می باشد.");
            });
        }
    }
}