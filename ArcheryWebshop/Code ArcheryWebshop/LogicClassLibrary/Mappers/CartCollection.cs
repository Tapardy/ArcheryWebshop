using DAL.DTO;
using DAL.Interface;
using WebshopClassLibrary.Interface;
using WebshopClassLibrary.Mappers.Interface;

namespace WebshopClassLibrary.Mappers;

public class CartCollection : ICartCollection
{
    public void AddCartItem(CartDTO cartDTO)
    {
        // Add the cart item entity to the database or any other storage mechanism
    }
}