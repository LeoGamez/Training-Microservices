using Catalog.Application.Models;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public string Id { get; set; } = String.Empty;
    }
}
