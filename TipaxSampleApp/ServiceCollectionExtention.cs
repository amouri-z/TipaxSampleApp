using TipaxSampleApp.Repositories.Implementations;
using TipaxSampleApp.Repositories.Interfaces;
using TipaxSampleApp.Services.Implementations;
using TipaxSampleApp.Services.Interfaces;
using TipaxSampleApp.Validators.Implementations;
using TipaxSampleApp.Validators.Interfaces;

namespace TipaxSampleApp
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }

        public static IServiceCollection AddServiceValidators(this IServiceCollection services)
        {
            services.AddTransient<ICustomerModelValidator, CustomerModelValidator>();
            services.AddTransient<ICustomerServiceValidator, CustomerServiceValidator>();
            return services;
        }
    }
}