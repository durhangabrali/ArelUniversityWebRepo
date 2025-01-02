using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastructure.AddAutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<ProductDtoForInsertion, Product>();
           CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

           CreateMap<CategoryDtoForInsertion, Category>();
           CreateMap<CategoryDtoForUpdate, Category>().ReverseMap();
        }
        
    }
}