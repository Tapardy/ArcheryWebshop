using DAL;
using Microsoft.AspNetCore.Mvc;
using WebshopClassLibrary;
using WebshopClassLibrary.Mappers;

namespace MvcArcheryWebshop.Controllers

{
    public class WishlistController : Controller
    {
        private readonly WishlistLogic _wishlistLogic;
        private readonly ProductService _productService;

        public WishlistController()
        {
            _productService = new ProductService(new ProductDAL());
            _wishlistLogic = new WishlistLogic(_productService);
        }

        public IActionResult Index()
        {
            var wishlistItems = HttpContext.Session.GetObject<List<WishlistItem>>("WishlistItems") ??
                                new List<WishlistItem>();
            var wishlistItemsWithDetails = _wishlistLogic.GetWishlistItemsWithProductDetails(wishlistItems);

            return View(wishlistItemsWithDetails);
        }

        [HttpPost]
        public IActionResult AddToWishlist(int productId)
        {
            var product = _productService.GetProductByID(productId);
            if (product != null)
            {
                var wishlistItem = new WishlistItem()
                {
                    ProductID = productId,
                    ProductName = product.Name,
                    Price = product.Price,
                };

                var wishlistItems = HttpContext.Session.GetObject<List<WishlistItem>>("WishlistItems") ??
                                    new List<WishlistItem>();

                // Pass the wishlist items to the logic layer for manipulation
                _wishlistLogic.AddToWishlist(wishlistItems, wishlistItem);

                // Update the wishlist items in the session
                HttpContext.Session.SetObject("WishlistItems", wishlistItems);
            }

            return RedirectToAction("Index", "Wishlist");
        }

        [HttpPost]
        public IActionResult RemoveFromWishlist(int productId)
        {
            var wishlistItems = HttpContext.Session.GetObject<List<WishlistItem>>("WishlistItems") ??
                                new List<WishlistItem>();

            // Pass the wishlist items to the logic layer for manipulation
            _wishlistLogic.RemoveFromWishlist(wishlistItems, productId);

            // Update the wishlist items in the session
            HttpContext.Session.SetObject("WishlistItems", wishlistItems);

            return RedirectToAction("Index", "Wishlist");
        }

        [HttpPost]
        public IActionResult ClearWishlist()
        {
            var wishlistItems = HttpContext.Session.GetObject<List<WishlistItem>>("WishlistItems") ??
                                new List<WishlistItem>();

            // Clear the wishlist items
            _wishlistLogic.ClearWishlist(wishlistItems);

            // Update the wishlist items in the session
            HttpContext.Session.SetObject("WishlistItems", wishlistItems);

            return RedirectToAction("Index", "Wishlist");
        }
    }
}