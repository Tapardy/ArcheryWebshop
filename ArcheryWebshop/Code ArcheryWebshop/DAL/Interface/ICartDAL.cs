using DAL.DTO;

namespace DAL.Interface;

public interface ICartDAL
{
    void AddCartItem(CartDTO cartItem);
    void RemoveCartItem(int cartItemId);
    void ClearCart();
    List<CartDTO> GetCartItems();
}