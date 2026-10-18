namespace ProductCatalogAPI.Dtos;

public record ProductResponseDto(Guid ID, string Name, string Category, decimal Price, int Stock);
public record CreateProductDto(string Name, string Category, decimal Price, int Stock);
public record UpdateProductDto(string Name, string Category, decimal Price, int Stock);