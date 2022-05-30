using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Repositories;
using MediatR;

namespace Catalog.Application.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<Product>(request.Product);
            await this.productRepository.CreateProduct(product);
            return Unit.Value;
        }
    }
}
