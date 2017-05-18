using AutoMapper;
using bdeliv_services.Controllers.Resources;
using bdeliv_services.Models;
using System.Linq;
using System.Collections.Generic;

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
            CreateMap<Product, ProductResource>()
                .ForMember(pr => pr.Tags, opt => opt.MapFrom(p => p.Tags.Select(pt => pt.TagId)));

            // API Resource to Domain
            CreateMap<ProductResource, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Tags, opt => opt.Ignore())
                .AfterMap((pr, p) => {
                   // Remove unselected tags
                   var removeTags = new List<ProductTags>();

                   foreach(var t in p.Tags)
                        if(!pr.Tags.Contains(t.TagId)) removeTags.Add(t);

                   foreach(var t in removeTags) p.Tags.Remove(t);
                       
                   // Add new tags
                   foreach(var id in pr.Tags)
                        if(!p.Tags.Any(t => t.TagId == id)) p.Tags.Add(new ProductTags { TagId = id });
                });
                
        }
    }
}