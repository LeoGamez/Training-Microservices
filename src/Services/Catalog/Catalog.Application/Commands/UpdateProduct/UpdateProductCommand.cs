using Catalog.Application.Models;
using MediatR;

namespace Catalog.Application.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public ProductDto Product { get; set; }
    }
}
