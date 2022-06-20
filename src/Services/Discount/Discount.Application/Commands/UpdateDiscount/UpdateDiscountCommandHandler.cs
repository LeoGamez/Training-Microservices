using AutoMapper;
using Discount.Domain.Entities;
using Discount.Infrastructure.Repositories;
using MediatR;

namespace Discount.Application.Commands
{
    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, bool>
    {
        private readonly IDiscountRepository repository;
        private readonly IMapper mapper;

        public UpdateDiscountCommandHandler(IDiscountRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = this.mapper.Map<Coupon>(request.Coupon);

            return await this.repository.UpdateDiscount(coupon);
        }
    }
}
