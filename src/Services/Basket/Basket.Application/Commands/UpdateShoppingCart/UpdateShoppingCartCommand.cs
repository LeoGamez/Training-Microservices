using Basket.Application.Models;
using MediatR;

namespace Basket.Application.Commands.UpdateShoppingCart
{
    public class UpdateShoppingCartCommand : IRequest<ShoppingCartDto>
    {
        public ShoppingCartDto ShoppingCart { get; set; }
    }
}
