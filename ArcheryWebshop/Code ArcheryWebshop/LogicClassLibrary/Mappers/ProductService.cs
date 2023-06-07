using DAL;
using DAL.DTO;
using DAL.Interface;

namespace WebshopClassLibrary.Mappers
{
    public class ProductService
    {
        private readonly IProductDAL _productDAL;

        public ProductService(IProductDAL productDal)
        {
            _productDAL = productDal;
        }
        
        private ProductDTO MapToDTO(Product product)
        {
            return new ProductDTO
            {
                ID = product.ID,
                CategoryName = product.CategoryName,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Description = product.Description
            };
        }

        private Product MapToProduct(ProductDTO dto)
        {
            return new Product
            {
                ID = dto.ID,
                CategoryName = dto.CategoryName,
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                Description = dto.Description
            };
        }

        public List<Product> GetProducts()
        {
            List<ProductDTO> productDTOs = _productDAL.GetProducts();
            List<Product> products = new List<Product>();
            foreach (ProductDTO dto in productDTOs)
            {
                Product product = MapToProduct(dto);
                products.Add(product);
            }

            return products;
        }
        
        public List<string> GetCategoryNames()
        {
            var categories = _productDAL.GetCategories(); // Adjust the method as per your implementation
            return categories.Select(category => category.Name).ToList();
        }

        public Product GetProductByID(int id)
        {
            ProductDTO dto = _productDAL.GetProductByID(id);
            if (dto != null)
            {
                Product product = MapToProduct(dto);
                return product;
            }

            return null;
        }

        public void AddProduct(Product product)
        {
            ProductDTO dto = MapToDTO(product);

            _productDAL.AddProduct(dto);
        }

        public void EditProduct(Product product)
        {
            ProductDTO dto = MapToDTO(product);
            _productDAL.EditProduct(dto);
        }

        public void DeleteProduct(int ID)
        {
            _productDAL.DeleteProduct(ID);
        }
    }
}
