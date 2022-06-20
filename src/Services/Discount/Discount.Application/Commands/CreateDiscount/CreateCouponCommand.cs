using Discount.Application.Models;
using MediatR;

namespace Discount.Application.Commands
{
    public class CreateDiscountCommand : IRequest<bool>
    {
        public CouponDto Coupon { get; set; }
    }
}
