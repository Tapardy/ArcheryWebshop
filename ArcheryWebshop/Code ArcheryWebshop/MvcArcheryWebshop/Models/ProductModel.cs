using WebshopClassLibrary;

namespace MvcArcheryWebshop.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; }
        public List<int> SelectedCategoryIds { get; set; }


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
            //initialize the lists to make the model state valid. if not initiated, the model state is invalid
            Categories = new List<string>();
            SelectedCategoryIds = new List<int>();
        }
    }
}