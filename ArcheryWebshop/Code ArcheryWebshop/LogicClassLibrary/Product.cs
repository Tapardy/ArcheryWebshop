namespace WebshopClassLibrary
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }

        public Product()
        {
            // Initialize the Categories collection in the constructor
            Categories = new List<Category>();
        }
    }
}