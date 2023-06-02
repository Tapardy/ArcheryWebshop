using DAL.DTO;
using DAL.Mock;
using WebshopClassLibrary;
using WebshopClassLibrary.Mappers;

namespace UnitTest
{
    [TestFixture]
    public class ProductServiceTests
    {
        private ProductService _productService;
        private MockProductDAL _mockProductDAL;

        [SetUp]
        public void SetUp()
        {
            _mockProductDAL = new MockProductDAL();
            _productService = new ProductService(_mockProductDAL);
        }

        [Test]
        public void GetProducts_ReturnsListOfProducts()
        {
            // Arrange
            var expectedProducts = new List<ProductDTO>
            {
                new ProductDTO { ID = 1, CategoryID = 1, Name = "Product 1" },
                new ProductDTO { ID = 2, CategoryID = 2, Name = "Product 2" },
                new ProductDTO { ID = 3, CategoryID = 3, Name = "Product 3" },
                new ProductDTO { ID = 4, CategoryID = 3, Name = "Product 4" }
            };
            foreach (var product in expectedProducts)
            {
                _mockProductDAL.AddProduct(product);
            }

            // Act
            var result = _productService.GetProducts();

            // Assert
            Assert.AreEqual(expectedProducts.Count, result.Count);
        }

        [Test]
        public void GetProductByID_ExistingID_ReturnsProduct()
        {
            // Arrange
            var expectedProduct = new ProductDTO { ID = 1, CategoryID = 1, Name = "Product 1" };
            _mockProductDAL.AddProduct(expectedProduct);

            // Act
            var result = _productService.GetProductByID(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedProduct.ID, result.ID);
        }

        [Test]
        public void GetProductByID_NonExistingID_ReturnsNull()
        {
            // Arrange
            // No need to add any products to the mockProductDAL

            // Act
            var result = _productService.GetProductByID(9999);

            // Assert
            Assert.IsNull(result);
        }
        
        [Test]
        public void AddProduct_ValidProduct_CreatesProduct()
        {
            // Arrange
            var newProduct = new Product
            {
                ID = 1,
                Name = "New Product",
                Price = 19.99m,
                Description = "New product description"
            };

            // Act
            _productService.AddProduct(newProduct);

            // Assert
            var createdProduct = _mockProductDAL.GetProductByID(newProduct.ID);
            Assert.IsNotNull(createdProduct);
            Assert.AreEqual(newProduct.Name, createdProduct.Name);
            Assert.AreEqual(newProduct.Price, createdProduct.Price);
            Assert.AreEqual(newProduct.Description, createdProduct.Description);
        }

        [Test]
        public void EditProduct_ValidProduct_EditsProduct()
        {
            // Arrange
            int productId = 1;
            var existingProduct = new ProductDTO
            {
                ID = productId,
                Name = "Existing Product",
                Price = 10.99m,
                Description = "Old description"
            };

            var updatedProduct = new Product
            {
                ID = productId,
                Name = "Updated Product",
                Price = 19.99m,
                Description = "New description"
            };

            _mockProductDAL.AddProduct(existingProduct);

            // Act
            _productService.EditProduct(updatedProduct);

            // Assert
            var editedProduct = _mockProductDAL.GetProductByID(productId);
            Assert.IsNotNull(editedProduct);
            Assert.AreEqual(updatedProduct.Name, editedProduct.Name);
            Assert.AreEqual(updatedProduct.Price, editedProduct.Price);
            Assert.AreEqual(updatedProduct.Description, editedProduct.Description);
        }
        
        [Test]
        public void DeleteProduct_ValidProduct_DeletesProduct()
        {
            // Arrange
            int productId = 1;
            var productToDelete = new ProductDTO
            {
                ID = productId,
                Name = "Product to Delete",
                Price = 9.99m,
                Description = "To be deleted"
            };

            _mockProductDAL.AddProduct(productToDelete);

            // Act
            _productService.DeleteProduct(productId);

            // Assert
            var deletedProduct = _mockProductDAL.GetProductByID(productId);
            Assert.IsNull(deletedProduct);
        }

    }
}
