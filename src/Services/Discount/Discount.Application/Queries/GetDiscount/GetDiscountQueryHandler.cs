using AutoMapper;
using Discount.Application.Models;
using Discount.Infrastructure.Repositories;
using MediatR;

namespace Discount.Application.Queries
{
    public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, CouponDto>
    {
        private readonly IDiscountRepository repository;
        private readonly IMapper mapper;

        public GetDiscountQueryHandler(IDiscountRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CouponDto> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            return this.mapper.Map<CouponDto>(await this.repository.GetDiscount(request.ProductName));
        }
    }
}
