using Basket.API.Services;
using Basket.Application.Commands.DeleteShoppingCart;
using Basket.Application.Commands.ShoppingCartCheckout;
using Basket.Application.Commands.UpdateShoppingCart;
using Basket.Application.Models;
using Basket.Application.Queries.GetShoppingCart;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator mediatr;
        private readonly IDiscountGrpcService discountGrpcService;

        public BasketController(IMediator mediatr, IDiscountGrpcService discountGrpcService)
        {
            this.mediatr = mediatr;
            this.discountGrpcService = discountGrpcService;
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCartDto), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetBasket(string userName)
        {
            var basket = await mediatr.Send(new GetShoppingCartQuery() { UserName = userName });

            return Ok(basket ?? new ShoppingCartDto { UserName = userName });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCartDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBasket([FromBody] UpdateShoppingCartCommand request)
        {
            foreach (var item in request.ShoppingCart.Items)
            {
                var coupon = await discountGrpcService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

            return Ok(await this.mediatr.Send(request));
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            return Ok(await this.mediatr.Send(new DeleteShoppingCartCommand() { UserName = userName }));
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] ShoppingCartCheckoutCommand request)
        {
            await this.mediatr.Send(request);
            return Accepted();
        }
    }
}
