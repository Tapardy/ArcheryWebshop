
using DAL.DTO;
using WebshopClassLibrary;

namespace MvcArcheryWebshop.Models;

public class CategoryModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string imageUrl { get; set; }

    public CategoryModel(Category category)
    {
        ID = category.ID;
        Name = category.Name;
        imageUrl = category.ImageUrl;
    }

    public CategoryModel()
    {
        
    }
    
    //TODO: More research on how to use the models, currently know it is for detailed info
}
