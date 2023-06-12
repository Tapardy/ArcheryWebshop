
using LogicLayer;
using WebshopClassLibrary.Mappers;

namespace WebshopClassLibrary
{
    public class WishlistLogic
    {
        private List<WishlistItem> _wishlistItems;
        private readonly ProductService _productService;

        public WishlistLogic(ProductService productService)
        {
            _wishlistItems = new List<WishlistItem>();
            _productService = productService;
        }

        public void AddToWishlist(List<WishlistItem> wishlistItems, WishlistItem newWishlistItem)
        {
            var existingWishlistItem =
                wishlistItems.FirstOrDefault(item => item.ProductID == newWishlistItem.ProductID);

            if (existingWishlistItem != null)
            {
                // Item already exists in the wishlist, do not add a duplicate
                return;
            }

            wishlistItems.Add(newWishlistItem);
        }

        public List<WishlistItem> GetWishlistItemsWithProductDetails(List<WishlistItem> wishlistItems)
        {
            var wishlistItemsWithDetails = new List<WishlistItem>();

            foreach (var wishlistItem in wishlistItems)
            {
                // Get the product details for each wishlist item and create a new wishlist item with details
                var product = _productService.GetProductByID(wishlistItem.ProductID);
                if (product != null)
                {
                    var wishlistItemWithDetails = new WishlistItem
                    {
                        ProductID = product.ID,
                        ProductName = product.Name,
                        Price = product.Price,
                        // Set other product details as needed
                    };

                    wishlistItemsWithDetails.Add(wishlistItemWithDetails);
                }
            }

            return wishlistItemsWithDetails;
        }

        public void RemoveFromWishlist(List<WishlistItem> wishlistItems, int productId)
        {
            var wishlistItem = wishlistItems.FirstOrDefault(item => item.ProductID == productId);
            if (wishlistItem != null)
            {
                wishlistItems.Remove(wishlistItem);
            }
        }

        public void ClearWishlist(List<WishlistItem> wishlistItems)
        {
            wishlistItems.Clear();
        }
    }
}