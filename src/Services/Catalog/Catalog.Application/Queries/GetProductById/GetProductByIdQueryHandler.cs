using AutoMapper;
using Catalog.Application.Models;
using Catalog.Infrastructure.Repositories;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await this.productRepository.GetProductById(request.Id);
            return mapper.Map<ProductDto>(product);
        }
    }
}
