using Discount.Application.Models;
using MediatR;

namespace Discount.Application.Queries
{
    public class GetDiscountQuery : IRequest<CouponDto>
    {
        public string ProductName { get; set; }
    }
}
