using DAL.DTO;

namespace DAL.Interface;

public interface IProductDAL
{
    ProductDTO GetProductByID(int id);
    List<ProductDTO> GetAllProducts();
    void AddProduct(ProductDTO product);
    void EditProduct(ProductDTO dto);
    void DeleteProduct(int id);
}