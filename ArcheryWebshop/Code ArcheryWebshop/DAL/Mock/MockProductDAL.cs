using DAL.DTO;
using DAL.Interface;

namespace DAL.Mock
{
    public class MockProductDAL : IProductDAL
    {
        private List<ProductDTO> _products;

        public MockProductDAL()
        {
            _products = new List<ProductDTO>();
        }
        
        public ProductDTO GetProductByID(int id)
        {
            //find the product in the mock list based on the id
            return _products.Find(p => p.ID == id);
        }


        public List<ProductDTO> GetAllProducts()
        {
            //return the mock list of products
            return _products;
        }

        public void AddProduct(ProductDTO dto)
        {
            //add the product to the mock list
            _products.Add(dto);
        }

        public void EditProduct(ProductDTO dto)
        {
            //update the product in the mock list
            int index = _products.FindIndex(p => p.ID == dto.ID);
            if (index != -1)
            {
                _products[index] = dto;
            }
        }

        public void DeleteProduct(int id)
        {
            //remove the product from the mock list
            ProductDTO product = _products.Find(p => p.ID == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}