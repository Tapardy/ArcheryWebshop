using DAL.DTO;

namespace DAL.Interface
{
    public interface IProductDAL
    {
        List<ProductDTO> GetProducts();
        ProductDTO GetProductByID(int id);
        // Other methods required by the Logic layer go here
    }
}
