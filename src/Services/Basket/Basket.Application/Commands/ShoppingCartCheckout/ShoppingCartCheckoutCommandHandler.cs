using Basket.Infrastructure.Repositories;
using MediatR;

namespace Basket.Application.Commands.ShoppingCartCheckout
{
    public class ShoppingCartCheckoutCommandHandler : IRequestHandler<ShoppingCartCheckoutCommand>
    {
        private readonly IBasketRepository basketRepository;

        public ShoppingCartCheckoutCommandHandler(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public async Task<Unit> Handle(ShoppingCartCheckoutCommand request, CancellationToken cancellationToken)
        {
            var basket = await this.basketRepository.GetBasket(request.ShoppingCart.UserName);

            await basketRepository.DeleteBasket(basket.UserName);

            return Unit.Value;
        }
    }
}
