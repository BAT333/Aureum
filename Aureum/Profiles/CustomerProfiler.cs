using Aureum.DTOs.CustomerDTO;
using Aureum.Models;
using AutoMapper;

namespace Aureum.Profiles
{
    public class CustomerProfiler : Profile
    {
        public CustomerProfiler()
        {
            CreateMap<Customer, ReadCustomerDTO>();
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<UpdateCustomerDTO, Customer>();

        }
    }
}
