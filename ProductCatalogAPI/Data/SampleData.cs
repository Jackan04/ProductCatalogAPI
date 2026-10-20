using System;
using ProductCatalogAPI.Models;

namespace ProductCatalogAPI.Data;

public class SampleData
{
    public List<Product> products = new()
    {
        new("Wireless Noise-Canceling Headphones", "electronics", 199.99m, 45),
        new("Mechanical Gaming Keyboard", "electronics", 89.50m, 120),
        new("Ultra-Wide 34-Inch Monitor", "electronics", 499.00m, 18),
        new("Ergonomic Mesh Office Chair", "furniture", 249.95m, 32),
        new("Electric Standing Desk", "furniture", 389.00m, 15),
        new("Solid Oak Bookshelf", "furniture", 175.25m, 8),
        new("Stainless Steel Water Bottle (32oz)", "accessories", 24.99m, 210),
        new("Leather Laptop Backpack", "accessories", 79.90m, 65),
        new("Polarized UV400 Sunglasses", "accessories", 35.00m, 140),
        new("Precision Kitchen Chef's Knife", "home & kitchen", 54.99m, 85),
        new("Cast Iron Skillet (12-inch)", "home & kitchen", 39.50m, 95),
        new("Programmable Drip Coffee Maker", "home & kitchen", 69.95m, 40)
    };
}
