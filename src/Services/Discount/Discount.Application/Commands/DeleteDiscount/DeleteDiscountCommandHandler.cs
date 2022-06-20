using Discount.Infrastructure.Repositories;
using MediatR;

namespace Discount.Application.Commands
{
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, bool>
    {
        private readonly IDiscountRepository repository;

        public DeleteDiscountCommandHandler(IDiscountRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.DeleteDiscount(request.ProductName);
        }
    }
}
