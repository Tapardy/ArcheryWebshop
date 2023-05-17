namespace WebshopClassLibrary.Interface
{
    public interface ICartLogic
    {
        List<CartItem> GetCartItemsWithProductDetails(List<CartItem> cartItems);
        void RemoveFromCart(List<CartItem> cartItems, int productId);
        void ClearCart(List<CartItem> cartItems);
        void AddToCart(List<CartItem> cartItems, CartItem newCartItem);
    }
}