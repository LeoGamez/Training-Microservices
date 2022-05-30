using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Repositories;
using MediatR;

namespace Catalog.Application.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<Product>(request.Product);
            return await this.productRepository.UpdateProduct(product);
        }
    }
}
