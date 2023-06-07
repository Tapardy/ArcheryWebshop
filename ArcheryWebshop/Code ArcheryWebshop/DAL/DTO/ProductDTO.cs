namespace DAL.DTO;

public class ProductDTO
{
    public int ID { get; set; }
    public int CategoryID { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }

    public ProductDTO(int id, string name, string imageUrl, decimal price, string description)
    {
        ID = id;
        Name = name;
        ImageUrl = imageUrl;
        Price = price;
        Description = description;
    }

    public ProductDTO(int id, string categoryName, string name, string imageUrl, decimal price, string description)
    {
        ID = id;
        CategoryName = categoryName;
        Name = name;
        ImageUrl = imageUrl;
        Price = price;
        Description = description;
    }

    public ProductDTO()
    {
    }
}