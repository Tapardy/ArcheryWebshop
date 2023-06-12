using DAL.Interface;

namespace WebshopClassLibrary.Mappers
{

    namespace LogicLayer
    {
        public class CategoryProductService
        {
            private readonly ICategoryProductDAL _categoryProductDal;

            public CategoryProductService(ICategoryProductDAL categoryProductDal)
            {
                _categoryProductDal = categoryProductDal;
            }

            public void AddCategoryToProduct(int categoryId, int productId)
            {
                _categoryProductDal.AddCategoryToProduct(categoryId, productId);
            }
            
            public List<int> GetCategoryIdsForProduct(int productId)
            {
                return _categoryProductDal.GetCategoryIdsForProduct(productId);
            }
            
            public void RemoveCategoriesFromProduct(int productId)
            {
                _categoryProductDal.RemoveCategoriesFromProduct(productId);
            }
        }
    }
}