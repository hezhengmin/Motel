using AutoMapper;
using Infrastructure.Models;
using Application.Paging;
using Application.ViewModels;
using System.Linq;

namespace Application.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            
            CreateMap<CustomerViewModel, Customer>();
          
            CreateMap<PaginatedList<Customer>, CustomerIndexViewModel>()
                .ForMember(dest => dest.CustomerViewModelList, opt => opt.MapFrom(src => src.ToList()));
        }
    }
}





