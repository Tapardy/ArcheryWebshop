using WebshopClassLibrary;

namespace MvcArcheryWebshop.Models;

public class IProductRepository
{
    public Product GetProductById(int productId)
    {
        List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Traditional Bow", Price = 400.00M, ImageUrl = "/images/TradBowImage.jpeg"  },
            new Product { Id = 2, Name = "Traditional Quiver", Price = 30.00M, ImageUrl = "/images/TradQuiverImage.webp" },
            new Product { Id = 3, Name = "Traditional Arrows x3", Price = 15.00M, ImageUrl = "/images/TradArrowImage.png" }
        };
        return products.FirstOrDefault(p => p.Id == productId);
    }
}