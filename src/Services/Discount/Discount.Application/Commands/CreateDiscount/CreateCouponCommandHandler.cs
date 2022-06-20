using AutoMapper;
using Discount.Domain.Entities;
using Discount.Infrastructure.Repositories;
using MediatR;

namespace Discount.Application.Commands
{
    public class CreateCouponCommandHandler : IRequestHandler<CreateDiscountCommand, bool>
    {
        private readonly IDiscountRepository repository;
        private readonly IMapper mapper;

        public CreateCouponCommandHandler(IDiscountRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = this.mapper.Map<Coupon>(request.Coupon);

            return await this.repository.CreateDiscount(coupon);
        }
    }
}
