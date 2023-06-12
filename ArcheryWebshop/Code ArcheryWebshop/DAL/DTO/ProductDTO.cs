namespace DAL.DTO;

public class ProductDTO
{
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public ProductDTO(int id, string name, string imageUrl, decimal price, string description)
    {
        ID = id;
        Name = name;
        ImageUrl = imageUrl;
        Price = price;
        Description = description;
    }

    public ProductDTO()
    {
    }
    
}