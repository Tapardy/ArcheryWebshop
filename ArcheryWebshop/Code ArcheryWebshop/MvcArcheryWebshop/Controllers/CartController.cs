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
        
        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            // Retrieve the product details based on the productId
            var product = _productCollection.GetProductByID(productId);
            if (product != null)
            {
                // Assuming you have a CartItemModel to represent the added product in the cart
                var cartItem = new CartItem()
                {
                    ProductID = productId,
                    Quantity = 1, // Set the desired quantity here
                };

                // Add the cartItem to the cart logic or perform any necessary operations
                _cartLogic.AddToCart(cartItem);
            }

            // Store the productId in TempData
            TempData["productId"] = productId;

            return RedirectToAction("Index", "Cart");
        }
        
        public IActionResult Index()
        {
            int? productId = TempData["productId"] as int?;

            var cartItems = _cartLogic.GetCartItemsWithProductDetails(productId ?? 0);
            var cartItemModels = cartItems.Select(cartItem => new CartItemModel(cartItem)).ToList();
            TempData.Clear();
            return View(cartItemModels);
        }
        
        // GET: Cart/Clear
        public ActionResult Clear()
        {
            _cartLogic.ClearCart();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart()
        {
            throw new NotImplementedException();
        }
    }
}

// public class CartController : Controller
// {
//     private readonly ICartLogic _cartLogic;
//
//     public CartController(ICartLogic cartLogic)
//     {
//         _cartLogic = cartLogic;
//     }
//
//     public IActionResult Index()
//     {
//         var cartItems = _cartLogic.GetCartItems();
//         var cartItemModels = cartItems.Select(cartItem => new CartItemModel
//         {
//             CartItemID = cartItem.CartItemID,
//             ProductID = cartItem.ProductID,
//             ProductName = cartItem.ProductName,
//             Quantity = cartItem.Quantity,
//             Price = cartItem.Price
//         }).ToList();
//         return View(cartItemModels);
//     }
//
//     [HttpPost]
//     public IActionResult AddToCart(int productID, int quantity)
//     {
//         _cartLogic.AddToCart(productID, quantity);
//
//         return RedirectToAction(nameof(Index));
//     }
//
//     public IActionResult RemoveFromCart(int cartItemID)
//     {
//         _cartLogic.RemoveFromCart(cartItemID);
//
//         return RedirectToAction(nameof(Index));
//     }
//
//     public IActionResult Clear()
//     {
//         _cartLogic.ClearCart();
//
//         return RedirectToAction(nameof(Index));
//     }
// }


//     public class CartController : Controller
//     {
//         private readonly ICartLogic _cartLogic;
//
//         public CartController(ICartLogic cartLogic)
//         {
//             _cartLogic = cartLogic;
//         }
//
//         public IActionResult Index()
//         {
//             var cartItems = _cartLogic.GetCartItems();
//             var cartItemModels = cartItems.Select(cartItem => new CartItemModel(cartItem)).ToList();
//             return View(cartItemModels);
//         }
//
//         public IActionResult AddToCart(int productId, int quantity)
//         {
//             _cartLogic.AddToCart(productId, quantity);
//
//             return RedirectToAction(nameof(Index));
//         }
//
//         public ActionResult RemoveFromCart(int cartItemId)
//         {
//             _cartLogic.RemoveFromCart(cartItemId);
//
//             return RedirectToAction(nameof(Index));
//         }
//
//         // Other actions for managing the cart
//
//         // GET: Cart/Clear
//         public ActionResult Clear()
//         {
//             _cartLogic.ClearCart();
//
//             return RedirectToAction(nameof(Index));
//         }
//     }
// }