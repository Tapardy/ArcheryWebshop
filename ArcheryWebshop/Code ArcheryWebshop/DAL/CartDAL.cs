using DAL.DTO;
using DAL.Interface;

namespace DAL;

public class CartDAL : ICartDAL
{
    private readonly List<CartDTO> _cartItems;

    public CartDAL()
    {
        _cartItems = new List<CartDTO>();
    }

    public void AddCartItem(CartDTO cartItem)
    {
        // Perform necessary data access operations to add cart item to the database
        // ...

        _cartItems.Add(cartItem);
    }

    public void RemoveCartItem(int cartItemID)
    {
        // Perform necessary data access operations to remove cart item from the database
        // ...

        var cartItem = _cartItems.Find(item => item.CartItemID == cartItemID);
        if (cartItem != null)
        {
            _cartItems.Remove(cartItem);
        }
    }

    public void ClearCart()
    {
        // Perform necessary data access operations to clear the cart in the database
        // ...

        _cartItems.Clear();
    }

    public List<CartDTO> GetCartItems()
    {
        // Perform necessary data access operations to retrieve cart items from the database
        // ...

        return _cartItems;
    }
}