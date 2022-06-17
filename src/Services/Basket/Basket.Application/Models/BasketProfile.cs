using AutoMapper;
using Basket.Domain.Entities;

namespace Basket.Application.Models
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<ShoppingCartDto, ShoppingCart>().ReverseMap();
            CreateMap<ShoppingCartItemDto, ShoppingCartItem>().ReverseMap();
        }
    }
}
