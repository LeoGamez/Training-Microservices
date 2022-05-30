using AutoMapper;
using Catalog.Application.Models;
using Catalog.Infrastructure.Repositories;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductByCategoryQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await this.productRepository.GetProductByCategory(request.Category);
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
