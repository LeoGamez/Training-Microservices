using AutoMapper;
using Catalog.Application.Models;
using Catalog.Domain.Entities;

namespace Catalog.Application.Queries.GetProducts
{
    public class GetProductsProfile : Profile
    {
        public GetProductsProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
