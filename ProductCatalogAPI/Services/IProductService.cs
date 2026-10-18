using ProductCatalogAPI.Dtos;

namespace ProductCatalogAPI.Services;

public interface IProductService
{
    public Task<IEnumerable<ProductResponseDto>> GetAllAsync(string? category);
    public Task<ProductResponseDto?> GetByIdAsync(Guid id);
    public Task<ProductResponseDto> CreateAsync(CreateProductDto dto);
    public Task<bool> UpdateAsync(Guid id, UpdateProductDto dto);
    public Task<bool> DeleteAsync(Guid id);
}
