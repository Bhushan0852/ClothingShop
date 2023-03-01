using AutoMapper;

namespace ClothingShop.API.Profiles
{
    public class Product : Profile
    {
        public Product()
        {
            CreateMap<Models.Domains.Product, Models.DTOs.ProductListDTO>().ReverseMap();
        }
    }
}
