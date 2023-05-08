using Microsoft.AspNetCore.Mvc;
using MvcArcheryWebshop.Models;
using WebshopClassLibrary;
using WebshopClassLibrary.Services;

namespace MvcArcheryWebshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<ProductModel> products = new List<ProductModel>();
            List<Product> productLogicList = _productService.GetProducts();

            foreach (var productLogic in productLogicList)
            {
                ProductModel productModel = new ProductModel
                {
                    ID = productLogic.ID,
                    Name = productLogic.Name,
                    ImageUrl = productLogic.ImageUrl,
                    Price = productLogic.Price,
                    Description = productLogic.Description
                };
                products.Add(productModel);
            }

            return View(products);
        }

        public IActionResult Details(int id)
        {
            Product product = _productService.GetProductByID(id);
            
            if (product == null)
            {
                return NotFound();
            }

            ProductModel productModel = new ProductModel
            {
                ID = product.ID,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Description = product.Description
            };

            return View(productModel);
        }
    }
}


// public IActionResult Index(int id)
// {
//     var product = _productRepository.GetProductById(id);
//     if (product == null)
//     {
//         return NotFound();
//     }
//
//     return View(product);
// }