using AutoMapper;
using WebApplication_api.Repository.Models.Entities;
using WebApplication_api.Services.DTO;


namespace WebApplication_api.Services.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            //CreateMap<ProductDTO, Product>();
        }
    }
}      