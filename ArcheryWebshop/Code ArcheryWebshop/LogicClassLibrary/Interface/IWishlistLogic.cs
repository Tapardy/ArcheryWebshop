namespace WebshopClassLibrary.Interface
{
    public interface IWishlistLogic
    {
        List<WishlistItem> GetWishlistItemsWithProductDetails(List<WishlistItem> wishlistItems);
        void RemoveFromWishlist(List<WishlistItem> wishlistItems, int productId);
        void ClearWishlist(List<WishlistItem> wishlistItems);
        void AddToWishlist(List<WishlistItem> wishlistItems, WishlistItem newWishlistItem);
    }
}