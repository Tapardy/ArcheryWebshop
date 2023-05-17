using DAL.DTO;
using DAL.Interface;

namespace WebshopClassLibrary.Mappers;

public class ProductCollection
{
    private readonly IProductDAL _productDAL;

    public ProductCollection(IProductDAL productDAL)
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

    public void AddProduct(Product product)
    {
        ProductDTO dto = new ProductDTO(
            product.ID,
            product.CategoryID,
            product.Name,
            product.ImageUrl,
            product.Price,
            product.Description
        );

        _productDAL.AddProduct(dto);
    }

    public void EditProduct(Product product)
    {
        ProductDTO dto = new ProductDTO(
            product.ID,
            product.Name,
            product.ImageUrl,
            product.Price,
            product.Description
        );
        _productDAL.EditProduct(dto);
    }

    public void DeleteProduct(int ID)
    {
        _productDAL.DeleteProduct(ID);
    }
}