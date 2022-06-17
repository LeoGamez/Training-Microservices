using Basket.Application.Models;
using MediatR;

namespace Basket.Application.Commands.ShoppingCartCheckout
{
    public class ShoppingCartCheckoutCommand : IRequest
    {
        public ShoppingCartDto ShoppingCart { get; set; }
    }
}
