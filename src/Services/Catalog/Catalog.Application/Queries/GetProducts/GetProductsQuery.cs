using Catalog.Application.Models;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
