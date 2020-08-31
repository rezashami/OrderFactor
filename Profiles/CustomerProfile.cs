using AutoMapper;
using Simulation.Dto;
using Simulation.Models;

namespace Simulation.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerPostDto, Customer>();
            CreateMap<Customer, CustomerGetDto>();
        }
    }
}