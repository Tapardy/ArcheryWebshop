using Microsoft.AspNetCore.Mvc;
using MvcArcheryWebshop.Models;

namespace MvcArcheryWebshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }

}
