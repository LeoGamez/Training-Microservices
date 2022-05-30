using Catalog.Application.Models;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductByCategoryQuery : IRequest<IEnumerable<ProductDto>>
    {
        public string Category { get; set; } = null!;
    }
}
