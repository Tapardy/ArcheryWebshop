using DAL.DTO;
using DAL.Interface;

namespace WebshopClassLibrary.Mappers
{
    public class CategoryService
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryService(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public List<Category> GetAllCategories()
        {
            List<CategoryDTO> categoryDtos = _categoryDAL.GetAllCategories();
            List<Category> categories = categoryDtos.Select(MapToCategory).ToList();
            return categories;
        }

        public List<string> GetCategoriesByIds(List<int> categoryIds)
        {
            List<CategoryDTO> categoryDtos = _categoryDAL.GetCategoriesByIds(categoryIds);
            List<string> categories = categoryDtos.Select(c => c.Name).ToList();
            return categories;
        }
        
        private Category MapToCategory(CategoryDTO categoryDto)
        {
            return new Category
            {
                ID = categoryDto.ID,
                Name = categoryDto.Name
            };
        }
    }
}