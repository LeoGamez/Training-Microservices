using MediatR;

namespace Catalog.Application.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
