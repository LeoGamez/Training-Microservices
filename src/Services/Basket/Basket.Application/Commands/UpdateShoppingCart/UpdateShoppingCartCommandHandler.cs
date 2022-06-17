using AutoMapper;
using Basket.Application.Models;
using Basket.Domain.Entities;
using Basket.Infrastructure.Repositories;
using MediatR;

namespace Basket.Application.Commands.UpdateShoppingCart
{
    public class UpdateShoppingCartCommandHandler : IRequestHandler<UpdateShoppingCartCommand, ShoppingCartDto>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public UpdateShoppingCartCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<ShoppingCartDto> Handle(UpdateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var basket = await this.basketRepository.UpdateBasket(this.mapper.Map<ShoppingCart>(request.ShoppingCart));

            return this.mapper.Map<ShoppingCartDto>(basket);
        }
    }
}
