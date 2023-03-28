using System.Collections.Generic;
using System.Linq;
using WebshopClassLibrary;


namespace MvcArcheryWebshop.Models
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public InMemoryProductRepository()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Traditional Bow",
                    Description = "A traditional wooden bow.",
                    Price = 400.00m,
                    ImageUrl = "images/TradBowImage.jpeg"
                },
                // Add more products here...
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}
