using ProductCatalogAPI.Data;
using ProductCatalogAPI.Dtos;
using ProductCatalogAPI.Services;

namespace ProductCatalogAPI.Tests;

public class ProductServiceTests
{
    private readonly ProductService _service;
    private readonly SampleData _data;

    public ProductServiceTests()
    {
        _data = new SampleData();
        _service = new ProductService(_data);
    }

    [Fact]
    public async Task GetAllAsync_WhenCalled_ReturnsInitialProducts()
    {
        var results = await _service.GetAllAsync(null);

        Assert.NotNull(results);
        Assert.NotEmpty(results);
    }

    [Fact]
    public async Task GetAllAsync_WhenCalledWithArgument_ReturnsCategoryProducts()
    {
        var category = "furniture";

        var results = await _service.GetAllAsync(category);

        Assert.NotNull(results);
        Assert.NotEmpty(results);
        Assert.All(results, product =>
            Assert.Equal(product.Category, category)
        );
    }

    [Fact]
    public async Task GetAllAsync_WhenCategoryDoesNotExist_ReturnsNoProducts()
    {
        var results = await _service.GetAllAsync("does-not-exist");

        Assert.Empty(results);
    }

    [Fact]
    public async Task GetByIdAsync_WhenCalled_ReturnsItem()
    {
        var dto = new CreateProductDto("Mouse", "technology", 600m, 12);
        var result = await _service.CreateAsync(dto);
        var item = await _service.GetByIdAsync(result.ID);

        Assert.NotNull(item);
    }

    [Fact]
    public async Task GetByIdAsync_WhenIdDoesNotExist_ReturnsNull()
    {
        var result = await _service.GetByIdAsync(Guid.NewGuid());

        Assert.Null(result);
    }

    [Fact]
    public async Task CreateAsync_WhenCalled_AddsAndReturnsProduct()
    {
        var dto = new CreateProductDto("Mouse", "technology", 600m, 12);

        var result = await _service.CreateAsync(dto);
        var products = await _service.GetAllAsync(null);

        Assert.Equal(dto.Name, result.Name);
        Assert.Equal(dto.Category, result.Category);
        Assert.Equal(dto.Price, result.Price);
        Assert.Equal(dto.Stock, result.Stock);
        Assert.Contains(products, product => product.ID == result.ID);
    }

    [Fact]
    public async Task UpdateAsync_WhenProductExists_UpdatesProduct()
    {
        var created = await _service.CreateAsync(
            new CreateProductDto("Mouse", "technology", 600m, 12));
        var update = new UpdateProductDto("Gaming Mouse", "electronics", 75m, 20);

        var result = await _service.UpdateAsync(created.ID, update);
        var updated = await _service.GetByIdAsync(created.ID);

        Assert.True(result);
        Assert.NotNull(updated);
        Assert.Equal(update.Name, updated.Name);
        Assert.Equal(update.Category, updated.Category);
        Assert.Equal(update.Price, updated.Price);
        Assert.Equal(update.Stock, updated.Stock);
    }

    [Fact]
    public async Task UpdateAsync_WhenProductDoesNotExist_ReturnsFalse()
    {
        var update = new UpdateProductDto("Gaming Mouse", "electronics", 75m, 20);

        var result = await _service.UpdateAsync(Guid.NewGuid(), update);

        Assert.False(result);
    }

    [Fact]
    public async Task DeleteAsync_WhenProductExists_RemovesProduct()
    {
        var created = await _service.CreateAsync(
            new CreateProductDto("Mouse", "technology", 600m, 12));

        var result = await _service.DeleteAsync(created.ID);
        var deleted = await _service.GetByIdAsync(created.ID);

        Assert.True(result);
        Assert.Null(deleted);
    }

    [Fact]
    public async Task DeleteAsync_WhenProductDoesNotExist_ReturnsFalse()
    {
        var result = await _service.DeleteAsync(Guid.NewGuid());

        Assert.False(result);
    }
}
