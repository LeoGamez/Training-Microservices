using Catalog.Application.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator mediatr;

        public CatalogController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProducts([FromBody] Application.Queries.GetProducts.GetProductsQuery request)
        {
            return await this.mediatr.Send(request);
        }
    }
}
