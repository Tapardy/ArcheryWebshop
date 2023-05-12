using DAL.DTO;

namespace WebshopClassLibrary.Interface
{
    public interface ICartLogic
        {
            List<CartItem> GetCartItemsWithProductDetails(int id);
            void RemoveFromCart(int cartItemId);
            void ClearCart();
            List<CartItem> GetCartItems();
            void AddToCart(CartItem cartItem);
        }
    }


    