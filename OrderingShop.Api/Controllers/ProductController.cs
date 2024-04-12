using Microsoft.AspNetCore.Mvc;
using OrderingShop.Domain.Interfaces;
using OrderingShop.Domain.Dtos;

namespace OrderingShop.Api.Controllers.ProductController
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger
            , IProductService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var result = await _service.GetAllProductsAsync();

            if (result.Any()) return Ok(result);

            _logger.LogInformation("Products not found");
            return NotFound("Products not found");
        }
    }
}
