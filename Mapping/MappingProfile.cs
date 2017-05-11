using AutoMapper;
using bdeliv_services.Controllers.Resources;
using bdeliv_services.Models;

namespace bdeliv_services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>();
        }
    }
}