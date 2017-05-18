using AutoMapper;
using bdeliv_services.Controllers.Resources;
using bdeliv_services.Models;
using System.Linq;

namespace bdeliv_services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource 
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<User, UserResource>();    

            // API Resource to Domain
            CreateMap<ProductResource, Product>()
                .ForMember(p => p.Tags, opt => opt.MapFrom(pr => pr.Tags.Select(id=> new ProductTags { TagId = id })));                             
        }
    }
}