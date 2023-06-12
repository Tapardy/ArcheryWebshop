using DAL.DTO;
using DAL.Mock;
using LogicLayer;
using WebshopClassLibrary;
using WebshopClassLibrary.Mappers;

namespace UnitTest
{
    [TestFixture]
    public class WishlistLogicTests
    {
        private WishlistLogic _wishlistLogic;
        private MockProductDAL _mockProductDAL;
        private ProductService _productService;

        [SetUp]
        public void SetUp()
        {
            _mockProductDAL = new MockProductDAL(); // Instantiate MockProductDAL
            _productService = new ProductService(_mockProductDAL); // Instantiate ProductService with MockProductDAL
            _wishlistLogic = new WishlistLogic(_productService);
        }

        [Test]
        public void AddToWishlist_ExistingWishlistItem_DoesNotAddDuplicate()
        {
            // Arrange
            var existingWishlistItem = new WishlistItem { ProductID = 1 };
            var wishlistItems = new List<WishlistItem> { existingWishlistItem };
            var newWishlistItem = new WishlistItem { ProductID = 1 };

            // Act
            _wishlistLogic.AddToWishlist(wishlistItems, newWishlistItem);

            // Assert
            Assert.AreEqual(1, wishlistItems.Count);
        }

        [Test]
        public void AddToWishlist_NewWishlistItem_AddsToWishlistItems()
        {
            // Arrange
            var wishlistItems = new List<WishlistItem>();
            var newWishlistItem = new WishlistItem { ProductID = 1 };

            // Act
            _wishlistLogic.AddToWishlist(wishlistItems, newWishlistItem);

            // Assert
            Assert.Contains(newWishlistItem, wishlistItems);
        }

        [Test]
        public void GetWishlistItemsWithProductDetails_ReturnsWishlistItemsWithDetails()
        {
            // Arrange
            var wishlistItems = new List<WishlistItem>
            {
                new WishlistItem { ProductID = 1 },
                new WishlistItem { ProductID = 2 }
            };

            // Add mock products to the mock DAL
            var product1 = new ProductDTO { ID = 1, Name = "Product 1", Price = 10.99m };
            var product2 = new ProductDTO { ID = 2, Name = "Product 2", Price = 19.99m };
            _mockProductDAL.AddProduct(product1);
            _mockProductDAL.AddProduct(product2);

            // Act
            var wishlistItemsWithDetails = _wishlistLogic.GetWishlistItemsWithProductDetails(wishlistItems);

            // Assert
            Assert.AreEqual(wishlistItems.Count, wishlistItemsWithDetails.Count);
            foreach (var wishlistItemWithDetails in wishlistItemsWithDetails)
            {
                Assert.IsNotNull(wishlistItemWithDetails.ProductName);
                Assert.IsNotNull(wishlistItemWithDetails.Price);
                // Add additional assertions for other product details as needed
            }
        }

        [Test]
        public void RemoveFromWishlist_ExistingWishlistItem_RemovesFromWishlistItems()
        {
            // Arrange
            var existingWishlistItem = new WishlistItem { ProductID = 1 };
            var wishlistItems = new List<WishlistItem> { existingWishlistItem };

            // Act
            _wishlistLogic.RemoveFromWishlist(wishlistItems, existingWishlistItem.ProductID);

            // Assert
            Assert.IsFalse(wishlistItems.Contains(existingWishlistItem));
        }

        [Test]
        public void ClearWishlist_RemovesAllWishlistItems()
        {
            // Arrange
            var wishlistItems = new List<WishlistItem>
            {
                new WishlistItem { ProductID = 1 },
                new WishlistItem { ProductID = 2 }
            };

            // Act
            _wishlistLogic.ClearWishlist(wishlistItems);

            // Assert
            Assert.IsEmpty(wishlistItems);
        }
    }
}
