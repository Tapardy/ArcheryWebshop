using DAL.DTO;

namespace DAL.Interface;

public interface ICategoryProductDAL
{
    void AddCategoryToProduct(int categoryId, int productId);
    void RemoveCategoriesFromProduct(int productId);
    List<int> GetCategoryIdsForProduct(int productId);
}