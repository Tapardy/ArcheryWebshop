// IProductRepository.cs
using System.Collections.Generic;
using WebshopClassLibrary;

public class IProductRepository
{
    IEnumerable<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Traditional Bow", Price = 400.00M, ImageUrl = "MvcMovie/wwwroot/images/TradBowImage.jpeg" },
            new Product { Id = 2, Name = "Compound Bow", Price = 600.00M, ImageUrl = "images/CompBowImage.jpeg" },
            new Product { Id = 3, Name = "Crossbow", Price = 800.00M, ImageUrl = "images/XBowImage.jpeg" }
        };
        return products;
    }

    public Product GetProductById(int productId)
    {
        List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Traditional Bow", Price = 400.00M, ImageUrl = "images/TradBowImage.jpeg" },
            new Product { Id = 2, Name = "Compound Bow", Price = 600.00M, ImageUrl = "images/CompBowImage.jpeg" },
            new Product { Id = 3, Name = "Crossbow", Price = 800.00M, ImageUrl = "images/XBowImage.jpeg" }
        };
        return products.FirstOrDefault(p => p.Id == productId);
    }
}
