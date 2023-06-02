using DAL;
using Microsoft.AspNetCore.Mvc;
using MvcArcheryWebshop.Models;
using WebshopClassLibrary.Mappers;

namespace MvcArcheryWebshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController()
        {
            _productService = new ProductService(new ProductDAL());
        }

        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            var productModels = products.Select(product => new ProductModel(product)).ToList();
            return View(productModels);
        }
    }
}