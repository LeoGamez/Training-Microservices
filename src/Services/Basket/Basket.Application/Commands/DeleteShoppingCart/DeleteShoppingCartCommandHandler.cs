using Basket.Infrastructure.Repositories;
using MediatR;

namespace Basket.Application.Commands.DeleteShoppingCart
{
    public class DeleteShoppingCartCommandHandler : IRequestHandler<DeleteShoppingCartCommand>
    {
        private readonly IBasketRepository basketRepository;

        public DeleteShoppingCartCommandHandler(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public async Task<Unit> Handle(DeleteShoppingCartCommand request, CancellationToken cancellationToken)
        {
            await this.basketRepository.DeleteBasket(request.UserName);

            return Unit.Value;
        }
    }
}
