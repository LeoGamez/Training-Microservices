using Discount.Application.Commands;
using Discount.Application.Models;
using Discount.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Discount.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator mediator;

        public DiscountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{productName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(CouponDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CouponDto>> GetDiscount(string productName)
        {
            var coupon = await this.mediator.Send(new GetDiscountQuery()
            {
                ProductName = productName
            });
            return Ok(coupon);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CouponDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CouponDto>> CreateDiscount([FromBody] CreateDiscountCommand request)
        {
            await this.mediator.Send(request);
            return CreatedAtRoute("GetDiscount", new { productName = request.Coupon.ProductName }, request.Coupon);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CouponDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CouponDto>> UpdateDiscount([FromBody] UpdateDiscountCommand request)
        {
            return Ok(await this.mediator.Send(request));
        }

        [HttpDelete("{productName}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDiscount(string productName)
        {
            return Ok(await this.mediator.Send(new DeleteDiscountCommand()
            {
                ProductName = productName
            }));
        }
    }
}
