using System.Collections.Generic;
using System.Linq;
using WebshopClassLibrary.Interface;
using WebshopClassLibrary.Mappers;

namespace WebshopClassLibrary
{
    public class CartLogic : ICartLogic
    {
        private List<CartItem> _cartItems;
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
        
        public void AddToCart(List<CartItem> cartItems, CartItem newCartItem)
        {
            var existingCartItem = cartItems.FirstOrDefault(item => item.ProductID == newCartItem.ProductID);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += newCartItem.Quantity;
            }
            else
            {
                cartItems.Add(newCartItem);
            }
        }

        public List<CartItem> GetCartItemsWithProductDetails(List<CartItem> cartItems)
        {
            var cartItemsWithDetails = new List<CartItem>();

            foreach (var cartItem in cartItems)
            {
                // Get the product details for each cart item and create a new cart item with details
                var product = _productCollection.GetProductByID(cartItem.ProductID);
                if (product != null)
                {
                    var cartItemWithDetails = new CartItem
                    {
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

        public void RemoveFromCart(List<CartItem> cartItems, int productId)
        {
            var cartItem = cartItems.FirstOrDefault(item => item.ProductID == productId);
            if (cartItem != null)
            {
                cartItems.Remove(cartItem);
            }
        }

        public void ClearCart(List<CartItem> cartItems)
        {
            cartItems.Clear();
        }

    }
}

//thin/rich