using AutoMapper;
using Catalog.Infrastructure.Repositories;
using MediatR;

namespace Catalog.Application.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await this.productRepository.GetProducts();
            var productsList = mapper.Map<IEnumerable<ProductDto>>(products);
            return productsList;
        }
    }
}
