using ProductCatalogAPI.Data;
using ProductCatalogAPI.Dtos;
using ProductCatalogAPI.Models;

namespace ProductCatalogAPI.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products;

    public ProductService(SampleData sampleData)
    {
        _products = sampleData.products;
    }

    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync(string? category)
    {
        var mapped = _products.Select(p => new ProductResponseDto(p.ID, p.Name, p.Category, p.Price, p.Stock));

        if (category is not null)
        {
            return mapped.Where(p => p.Category == category);
        }

        return mapped ?? Enumerable.Empty<ProductResponseDto>();
    }

    public async Task<ProductResponseDto?> GetByIdAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.ID == id);

        return product is null
            ? null
            : new ProductResponseDto(product.ID ,product.Name, product.Category, product.Price, product.Stock);

    }
    public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
    {
        var product = new Product(dto.Name, dto.Category, dto.Price, dto.Stock);
        _products.Add(product);

        return new ProductResponseDto(product.ID, product.Name, product.Category, product.Price, product.Stock);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.ID == id);

        return product is not null && _products.Remove(product);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateProductDto dto)
    {
        var existingProduct = _products.FirstOrDefault(p => p.ID == id);
      
        if(existingProduct is null) return false; 

        var index = _products.IndexOf(existingProduct);

        _products[index] = existingProduct with
        {
            Name = dto.Name,
            Category = dto.Category,
            Price = dto.Price,
            Stock = dto.Stock
        };

        return true;
    }
}
