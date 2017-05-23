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
            CreateMap<Category, KeyValuePairResource>();
            CreateMap<Product, SaveProductResource>();
            CreateMap<User, UserResource>();    
            CreateMap<Product, SaveProductResource>()
                .ForMember(pr => pr.Tags, opt => opt.MapFrom(p => p.Tags.Select(pt => pt.TagId)));

            CreateMap<Product, ProductResource>()
                .ForMember(pr => pr.Tags, opt => opt.MapFrom(p => p.Tags.Select(pt => new KeyValuePairResource { Id = pt.Tag.Id, Name = pt.Tag.Name })));

            // API Resource to Domain
            CreateMap<SaveProductResource, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Tags, opt => opt.Ignore())
                .AfterMap((pr, p) => {
                   
                    // Remove unselected tags
                    var removedTags = p.Tags.Where(t => !pr.Tags.Contains(t.TagId));
                    foreach(var t in removedTags) 
                        p.Tags.Remove(t);
                       
                   // Add new tags
                    var addedTags = pr.Tags.Where(id => !p.Tags.Any(t => t.TagId == id)).Select(id => new ProductTags { TagId = id });
                    foreach(var t in addedTags)
                        p.Tags.Add(t);
                
                });
                
        }
    }
}