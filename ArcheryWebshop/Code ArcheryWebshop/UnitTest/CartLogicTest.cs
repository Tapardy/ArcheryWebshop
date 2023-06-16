using DAL.DTO;
using DAL.Mock;
using WebshopClassLibrary;
using WebshopClassLibrary.Mappers;

namespace UnitTest
{
    [TestFixture]
    public class CartLogicTests
    {
        private CartLogic _cartLogic;
        private MockProductDAL _mockProductDAL;
        private ProductService _productService;

        [SetUp]
        public void SetUp()
        {
            _mockProductDAL = new MockProductDAL(); // Instantiate MockProductDAL
            _productService = new ProductService(_mockProductDAL); // Instantiate ProductService with MockProductDAL
            _cartLogic = new CartLogic(_productService);
        }

        [Test]
        public void AddToCart_ExistingCartItem_IncrementsQuantity()
        {
            // Arrange
            var existingCartItem = new CartItem { ProductID = 1, Quantity = 2 };
            var cartItems = new List<CartItem> { existingCartItem };
            var newCartItem = new CartItem { ProductID = 1, Quantity = 3 };

            // Act
            _cartLogic.AddToCart(cartItems, newCartItem);

            // Assert
            Assert.AreEqual(5, existingCartItem.Quantity);
        }

        [Test]
        public void AddToCart_NewCartItem_AddsToCartItems()
        {
            // Arrange
            var cartItems = new List<CartItem>();
            var newCartItem = new CartItem { ProductID = 1, Quantity = 3 };

            // Act
            _cartLogic.AddToCart(cartItems, newCartItem);

            // Assert
            Assert.Contains(newCartItem, cartItems);
        }

        [Test]
        public void GetCartItemsWithProductDetails_ReturnsCartItemsWithDetails()
        {
            // Arrange
            var cartItems = new List<CartItem>
            {
                new CartItem { ProductID = 1, Quantity = 2 },
                new CartItem { ProductID = 2, Quantity = 1 }
            };

            var mockProduct1 = new ProductDTO { ID = 1, Name = "Product 1", Price = 10.99m };
            var mockProduct2 = new ProductDTO { ID = 2, Name = "Product 2", Price = 30.99m };
            _mockProductDAL.AddProduct(mockProduct1);
            _mockProductDAL.AddProduct(mockProduct2);

            // Act
            var cartItemsWithDetails = _cartLogic.GetCartItemsWithProductDetails(cartItems);

            // Assert
            Assert.AreEqual(cartItems.Count, cartItemsWithDetails.Count);
            foreach (var cartItemWithDetails in cartItemsWithDetails)
            {
                Assert.IsNotNull(cartItemWithDetails.ProductName);
                Assert.IsNotNull(cartItemWithDetails.Price);
                // Add additional assertions for other product details as needed
            }
        }

        [Test]
        public void RemoveFromCart_ExistingCartItem_DecrementsQuantity()
        {
            // Arrange
            var existingCartItem = new CartItem { ProductID = 1, Quantity = 2 };
            var cartItems = new List<CartItem> { existingCartItem };

            // Act
            _cartLogic.RemoveFromCart(cartItems, existingCartItem.ProductID);

            // Assert
            Assert.AreEqual(1, existingCartItem.Quantity);
        }

        [Test]
        public void RemoveFromCart_ExistingCartItemWithQuantityOne_RemovesFromCartItems()
        {
            // Arrange
            var existingCartItem = new CartItem { ProductID = 1, Quantity = 1 };
            var cartItems = new List<CartItem> { existingCartItem };

            // Act
            _cartLogic.RemoveFromCart(cartItems, existingCartItem.ProductID);

            // Assert
            Assert.IsFalse(cartItems.Contains(existingCartItem));
        }

        [Test]
        public void ClearCart_RemovesAllCartItems()
        {
            // Arrange
            var cartItems = new List<CartItem>
            {
                new CartItem { ProductID = 1, Quantity = 2 },
                new CartItem { ProductID = 2, Quantity = 1 }
            };

            // Act
            _cartLogic.ClearCart(cartItems);

            // Assert
            Assert.IsEmpty(cartItems);
        }
    }
}