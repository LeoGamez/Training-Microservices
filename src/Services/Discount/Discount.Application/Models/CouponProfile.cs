using AutoMapper;
using Discount.Domain.Entities;

namespace Discount.Application.Models
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<CouponDto, Coupon>().ReverseMap();
        }
    }
}
