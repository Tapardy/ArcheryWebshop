using DAL;
using DAL.DTO;
using System.Collections.Generic;
using DAL.Interface;

namespace WebshopClassLibrary.Mappers;

public class CategoryService
{
    private readonly ICategoryDAL _categoryDAL;

    public CategoryService(ICategoryDAL categoryDAL)
    {
        _categoryDAL = categoryDAL;
    }

    public List<Category> GetCategories()
    {
        List<CategoryDTO> categoryDTOs = _categoryDAL.GetCategories();
        List<Category> categories = new List<Category>();
        foreach (CategoryDTO dto in categoryDTOs)
        {
            Category category = new Category
            {
                ID = dto.ID,
                //Name = dto.Name,id
                ImageUrl = dto.ImageUrl,
            };
            categories.Add(category);
        }

        return categories;
    }


    public CategoryDTO GetCategoryById(int categoryId)
    {
        return _categoryDAL.GetCategoryById(categoryId);
    }

    public void AddCategory(CategoryDTO category)
    {
        _categoryDAL.AddCategory(category);
    }

    public void DeleteCategory(int categoryId)
    {
        _categoryDAL.DeleteCategory(categoryId);
    }
}