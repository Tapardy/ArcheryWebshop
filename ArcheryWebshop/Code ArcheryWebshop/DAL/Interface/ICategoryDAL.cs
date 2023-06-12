using DAL.DTO;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface ICategoryDAL
    {
        List<CategoryDTO> GetAllCategories();
        List<CategoryDTO> GetCategoriesByIds(List<int> categoryIds);
    }
}