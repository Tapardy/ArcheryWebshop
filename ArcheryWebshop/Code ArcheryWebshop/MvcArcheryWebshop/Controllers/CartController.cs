using Microsoft.AspNetCore.Mvc;
using MvcArcheryWebshop.Models;
using WebshopClassLibrary;
using WebshopClassLibrary.Interface;
using WebshopClassLibrary.Mappers;

namespace MvcArcheryWebshop.Controllers

{
    public class CartController : Controller
    {
        private readonly ICartLogic _cartLogic;
        private readonly ProductCollection _productCollection;

        public CartController(ICartLogic cartLogic, ProductCollection productCollection)
        {
            _cartLogic = cartLogic;
            _productCollection = productCollection;
        }

        public IActionResult Index()
        {
            var cartItems = HttpContext.Session.GetObject<List<CartItem>>("CartItems") ?? new List<CartItem>();
            var cartItemsWithDetails = _cartLogic.GetCartItemsWithProductDetails(cartItems);

            return View(cartItemsWithDetails);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _productCollection.GetProductByID(productId);
            if (product != null)
            {
                var cartItem = new CartItem()
                {
                    ProductID = productId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1 // Set the desired quantity here
                };

                var cartItems = HttpContext.Session.GetObject<List<CartItem>>("CartItems") ?? new List<CartItem>();

                // Pass the cart items to the logic layer for manipulation
                _cartLogic.AddToCart(cartItems, cartItem);

                // Update the cart items in the session
                HttpContext.Session.SetObject("CartItems", cartItems);
            }

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cartItems = HttpContext.Session.GetObject<List<CartItem>>("CartItems") ?? new List<CartItem>();

            // Pass the cart items to the logic layer for manipulation
            _cartLogic.RemoveFromCart(cartItems, productId);

            // Update the cart items in the session
            HttpContext.Session.SetObject("CartItems", cartItems);

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            var cartItems = HttpContext.Session.GetObject<List<CartItem>>("CartItems") ?? new List<CartItem>();

            // Clear the cart items
            _cartLogic.ClearCart(cartItems);

            // Update the cart items in the session
            HttpContext.Session.SetObject("CartItems", cartItems);

            return RedirectToAction("Index", "Cart");
        }
    }
}