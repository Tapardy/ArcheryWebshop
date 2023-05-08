using DAL.DTO;
using DAL.Interface;

namespace WebshopClassLibrary.Services;

public class ProductService
{
    private readonly IProductDAL _productDAL;

    public ProductService(IProductDAL productDAL)
    {
        _productDAL = productDAL;
    }

    public List<Product> GetProducts()
    {
        List<ProductDTO> productDTOs = _productDAL.GetProducts();
        List<Product> products = new List<Product>();
        foreach (ProductDTO dto in productDTOs)
        {
            Product product = new Product
            {
                ID = dto.ID,
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                Description = dto.Description
            };
            products.Add(product);
        }
        return products;
    }
    public Product GetProductByID(int id)
    {
        ProductDTO dto = _productDAL.GetProductByID(id);
        if (dto != null)
        {
            Product product = new Product
            {
                ID = dto.ID,
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                Description = dto.Description
            };
            return product;
        }
        return null;
    }
}