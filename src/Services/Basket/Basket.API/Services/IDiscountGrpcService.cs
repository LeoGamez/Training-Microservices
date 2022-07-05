using Discount.Application.Protos;

namespace Basket.API.Services
{
    public interface IDiscountGrpcService
    {
        Task<CouponModel> GetDiscount(string productName);
    }
}