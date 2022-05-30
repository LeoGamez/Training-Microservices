using Catalog.Application.Models;
using MediatR;

namespace Catalog.Application.Commands
{
    public class CreateProductCommand : IRequest
    {
        public ProductDto Product { get; set; }
    }
}
