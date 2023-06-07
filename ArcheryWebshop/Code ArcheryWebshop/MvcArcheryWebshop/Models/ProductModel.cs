using WebshopClassLibrary;

namespace MvcArcheryWebshop.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }

        public ProductModel(Product product)
        {
            ID = product.ID;
            Name = product.Name;
            ImageUrl = product.ImageUrl;
            Price = product.Price;
            Description = product.Description;
        }

        public ProductModel()
        {
        }
    }
}