using AutoMapper;
using Basket.Application.Models;
using Basket.Infrastructure.Repositories;
using MediatR;

namespace Basket.Application.Queries.GetShoppingCart
{
    public class GetShoppingCartQueryHandler : IRequestHandler<GetShoppingCartQuery, ShoppingCartDto>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public GetShoppingCartQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<ShoppingCartDto> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
        {
            var basket = await this.basketRepository.GetBasket(request.UserName);
            return this.mapper.Map<ShoppingCartDto>(basket);
        }
    }
}
