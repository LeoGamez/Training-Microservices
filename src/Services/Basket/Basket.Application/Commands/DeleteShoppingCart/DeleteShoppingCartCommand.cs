using MediatR;

namespace Basket.Application.Commands.DeleteShoppingCart
{
    public class DeleteShoppingCartCommand : IRequest
    {
        public string UserName { get; set; }
    }
}
