using AutoMapper;
using CustomerManagementApi.DTOs;
using CustomerManagementApi.Models;

namespace CustomerManagementApi.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerRequest, Customer>();
        }
    }
}
