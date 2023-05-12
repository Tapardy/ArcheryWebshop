using DAL.DTO;

namespace DAL.Interface
{
    public interface ICategoryDAL
    {
        List<CategoryDTO> GetCategories();
        CategoryDTO GetCategoryById(int categoryId);
        void AddCategory(CategoryDTO category);
        void EditCategory(CategoryDTO category);
        void DeleteCategory(int categoryId);
    }
}