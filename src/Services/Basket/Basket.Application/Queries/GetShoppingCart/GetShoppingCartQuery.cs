using Basket.Application.Models;
using MediatR;

namespace Basket.Application.Queries.GetShoppingCart
{
    public class GetShoppingCartQuery : IRequest<ShoppingCartDto>
    {
        public string UserName { get; set; }
    }
}
