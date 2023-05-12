using System.Collections.Generic;
using System.Linq;
using WebshopClassLibrary.Interface;
using WebshopClassLibrary.Mappers;

namespace WebshopClassLibrary
{
    public class CartLogic : ICartLogic
    {
        private readonly List<CartItem> _cartItems;
        private readonly ProductCollection _productCollection;

        public CartLogic(ProductCollection productCollection)
        {
            _cartItems = new List<CartItem>();
            _productCollection = productCollection;
        }
        
        public List<CartItem> GetCartItems()
        {
            return _cartItems;
        }
        public List<CartItem> GetCartItemsWithProductDetails(int id)
        {
            var cartItemsWithDetails = new List<CartItem>();
            foreach (var cartItem in _cartItems)
            {
                var product = _productCollection.GetProductByID(id);
                    if (product != null)
                    {
                        var cartItemWithDetails = new CartItem
                        {
                            CartItemID = cartItem.CartItemID,
                            Quantity = cartItem.Quantity,
                            ProductID = product.ID,
                            ProductName = product.Name,
                            Price = product.Price,
                            // Set other product details as needed
                        };

                        cartItemsWithDetails.Add(cartItemWithDetails);
                    }
            }

            return cartItemsWithDetails;
        }


        public void AddToCart(CartItem cartItem)
        {
            // Check if the cart item already exists in the cart
            var existingCartItem = _cartItems.FirstOrDefault(item => item.ProductID == cartItem.ProductID);
            if (existingCartItem != null)
            {
                // If the cart item exists, update its quantity
                existingCartItem.Quantity += cartItem.Quantity;
            }
            else
            {
                // If the cart item doesn't exist, add it to the cart
                _cartItems.Add(cartItem);
            }
        }

        public void RemoveFromCart(int cartItemId)
        {
            var cartItem = _cartItems.Find(item => item.CartItemID == cartItemId);
            if (cartItem != null)
            {
                _cartItems.Remove(cartItem);
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }
    }
}

//thin/rich