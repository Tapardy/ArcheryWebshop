using DAL.DTO;
using DAL.Interface;

namespace WebshopClassLibrary
{
    public class Product
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        
    }

}