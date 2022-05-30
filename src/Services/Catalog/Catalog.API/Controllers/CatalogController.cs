using Catalog.Application.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator mediatr;

        public CatalogController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return await this.mediatr.Send(new GetProductsQuery());
        }
    }
}
