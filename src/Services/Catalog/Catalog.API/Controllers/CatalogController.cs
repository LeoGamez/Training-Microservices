using Catalog.Application.Commands;
using Catalog.Application.Models;
using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator mediatr;
        private readonly ILogger<CatalogController> logger;

        public CatalogController(
            IMediator mediatr,
            ILogger<CatalogController> logger)
        {
            this.mediatr = mediatr;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            return Ok(await this.mediatr.Send(new GetProductsQuery()));
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDto>> GetProduct(string id)
        {
            var product = await this.mediatr.Send(new GetProductByIdQuery()
            {
                Id = id
            });

            if (product == null)
            {
                logger.LogError($"Product with id: {id} not found");
                return NotFound();
            }

            return Ok(product);
        }

        [Route("[action]/{category}", Name = "GetProductsByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductByCategory(string category)
        {
            var products = await this.mediatr.Send(new GetProductByCategoryQuery()
            {
                Category = category
            });

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProductDto>>> PostProduct([FromBody] CreateProductCommand request)
        {
            await this.mediatr.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<ProductDto>>> PutProduct([FromBody] UpdateProductCommand request)
        {
            await this.mediatr.Send(request);
            return Ok();
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> DeleteProduct(string id)
        {
            await this.mediatr.Send(new DeleteProductCommand() { Id = id });
            return Ok();
        }
    }
}
