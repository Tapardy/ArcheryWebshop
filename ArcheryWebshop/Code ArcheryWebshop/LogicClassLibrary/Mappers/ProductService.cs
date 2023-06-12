using System.Collections.Generic;
using System.Linq;
using DAL.DTO;
using DAL.Interface;
using WebshopClassLibrary;

namespace LogicLayer
{
    public class ProductService
    {
        private readonly IProductDAL _productDal;

        public ProductService(IProductDAL productDal)
        {
            _productDal = productDal;
        }

        public Product GetProductByID(int id)
        {
            ProductDTO productDto = _productDal.GetProductByID(id);
            if (productDto == null)
            {
                return null;
            }

            return MapToProduct(productDto);
        }

        public List<Product> GetAllProducts()
        {
            List<ProductDTO> productDtos = _productDal.GetAllProducts();
            List<Product> products = productDtos.Select(MapToProduct).ToList();

            return products;
        }

        public void AddProduct(Product product)
        {
            ProductDTO productDto = MapToProductDto(product);
            _productDal.AddProduct(
                productDto); // Update the AddProduct method in the DAL to return the generated product ID
        }

        public void EditProduct(Product product)
        {
            ProductDTO productDto = MapToProductDto(product);
            _productDal.EditProduct(productDto);
        }

        public void DeleteProduct(int ID)
        {
            // Delete the product
            _productDal.DeleteProduct(ID);
        }

        private Product MapToProduct(ProductDTO productDto)
        {
            return new Product
            {
                ID = productDto.ID,
                Name = productDto.Name,
                ImageUrl = productDto.ImageUrl,
                Price = productDto.Price,
                Description = productDto.Description
            };
        }

        private ProductDTO MapToProductDto(Product product)
        {
            return new ProductDTO
            {
                ID = product.ID,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Description = product.Description
            };
        }
    }
}