using System.Collections.Generic;
using System.Linq;
using WebshopClassLibrary.Mappers;

namespace WebshopClassLibrary
{
    public class CartLogic
    {
        private List<CartItem> _cartItems;
        private readonly ProductService _productService;

        public CartLogic(ProductService productService)
        {
            _cartItems = new List<CartItem>();
            _productService = productService;
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
                var product = _productService.GetProductByID(cartItem.ProductID);
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
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    cartItems.Remove(cartItem);
                }
            }
        }

        public void ClearCart(List<CartItem> cartItems)
        {
            cartItems.Clear();
        }
    }
}