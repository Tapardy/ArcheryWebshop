using Microsoft.AspNetCore.Mvc;
using MvcArcheryWebshop.Models;
using WebshopClassLibrary;
using WebshopClassLibrary.Services;

namespace MvcArcheryWebshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            //Show featured products
            var products = _productService.GetProducts();

            var productModels = new List<ProductModel>();

            foreach (var product in products)
            {
                var productModel = new ProductModel
                {
                    ID = product.ID,
                    Name = product.Name,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Description = product.Description
                };

                productModels.Add(productModel);
            }

            return View(productModels);
        }
    }
}