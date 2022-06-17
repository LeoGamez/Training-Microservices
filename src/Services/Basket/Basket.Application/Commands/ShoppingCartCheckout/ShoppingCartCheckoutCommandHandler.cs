using AutoMapper;
using Basket.Infrastructure.Repositories;
using MediatR;

namespace Basket.Application.Commands.ShoppingCartCheckout
{
    public class ShoppingCartCheckoutCommandHandler : IRequestHandler<ShoppingCartCheckoutCommand>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public ShoppingCartCheckoutCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(ShoppingCartCheckoutCommand request, CancellationToken cancellationToken)
        {
            var basket = await this.basketRepository.GetBasket(request.ShoppingCart.UserName);

            //send checkout to rabbitmq

            // remove the basket
            await basketRepository.DeleteBasket(basket.UserName);

            return Unit.Value;
        }
    }
}
