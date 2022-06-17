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
        private readonly ILogger<BasketController> logger;

        public BasketController(IMediator mediatr, ILogger<BasketController> logger)
        {
            this.mediatr = mediatr;
            this.logger = logger;
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
