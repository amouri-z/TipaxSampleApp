using AutoMapper;
using TipaxSampleApp.Models;
using TipaxSampleApp.ViewModels;

namespace TipaxSampleApp.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerBindingModel, CustomerDto>();
            CreateMap<CustomerDto, CustomerViewModel>();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}