using AutoMapper;
using Catalog.Infrastructure.Repositories;
using MediatR;

namespace Catalog.Application.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await this.productRepository.DeleteProduct(request.Id);
        }
    }
}
