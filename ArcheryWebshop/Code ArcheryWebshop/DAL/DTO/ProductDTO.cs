namespace DAL.DTO;

public class ProductDTO
{
    public int ID { get; private set; }
    public int CategoryID { get; private set; }
    public string Name { get; private set; }
    public string ImageUrl { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }

    public ProductDTO(int id, string name, string imageUrl, decimal price, string description)
    {
        ID = id;
        Name = name;
        ImageUrl = imageUrl;
        Price = price;
        Description = description;
    }

    public ProductDTO(int id, int categoryId, string name, string imageUrl, decimal price, string description)
    {
        ID = id;
        CategoryID = categoryId;
        Name = name;
        ImageUrl = imageUrl;
        Price = price;
        Description = description;
    }
}