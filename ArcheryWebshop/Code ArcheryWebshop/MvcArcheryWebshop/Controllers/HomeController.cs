using Microsoft.AspNetCore.Mvc;
using MvcArcheryWebshop.Models;
using WebshopClassLibrary;
using WebshopClassLibrary.Mappers;

namespace MvcArcheryWebshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductCollection _productCollection;

        public HomeController(ProductCollection productCollection)
        {
            _productCollection = productCollection;
        }

        public IActionResult Index()
        {
            var products = _productCollection.GetProducts();
            var productModels = products.Select(product => new ProductModel(product)).ToList();
            return View(productModels);
        }
    }
}