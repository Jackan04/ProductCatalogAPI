using System;
using ProductCatalogAPI.Models;

namespace ProductCatalogAPI.Data;

public class SampleData
{
    public List<Product> products = new()
    {
        new("Wireless Noise-Canceling Headphones", "Electronics", 199.99m, 45),
        new("Mechanical Gaming Keyboard", "Electronics", 89.50m, 120),
        new("Ultra-Wide 34-Inch Monitor", "Electronics", 499.00m, 18),
        new("Ergonomic Mesh Office Chair", "Furniture", 249.95m, 32),
        new("Electric Standing Desk", "Furniture", 389.00m, 15),
        new("Solid Oak Bookshelf", "Furniture", 175.25m, 8),
        new("Stainless Steel Water Bottle (32oz)", "Accessories", 24.99m, 210),
        new("Leather Laptop Backpack", "Accessories", 79.90m, 65),
        new("Polarized UV400 Sunglasses", "Accessories", 35.00m, 140),
        new("Precision Kitchen Chef's Knife", "Home & Kitchen", 54.99m, 85),
        new("Cast Iron Skillet (12-inch)", "Home & Kitchen", 39.50m, 95),
        new("Programmable Drip Coffee Maker", "Home & Kitchen", 69.95m, 40)
    };
}
