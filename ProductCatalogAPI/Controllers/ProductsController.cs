using Microsoft.AspNetCore.Mvc;
using ProductCatalogAPI.Dtos;
using ProductCatalogAPI.Services;

namespace ProductCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> Get([FromQuery] string? category)
        {
            var products = await _service.GetAllAsync(category);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetById(Guid id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product is null)
            {
                return NotFound($"Product not found ({id})");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDto>> Create([FromBody] CreateProductDto dto)
        {
            var newProduct = await _service.CreateAsync(dto);

            return Ok(newProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(Guid id, [FromBody] UpdateProductDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);

            if(!success) return NotFound($"Product not found ({id})");
            
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);

            if(!success) return NotFound($"Product not found ({id})");

            return NoContent();
        }
    }
}