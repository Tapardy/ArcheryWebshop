using Microsoft.AspNetCore.Mvc;
using MvcArcheryWebshop.Models;
using WebshopClassLibrary;
using WebshopClassLibrary.Mappers;

namespace MvcArcheryWebshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductCollection _productCollection;

        public ProductController(ProductCollection productCollection)
        {
            _productCollection = productCollection;
        }

        public IActionResult Index()
        {
            var products = _productCollection.GetProducts();
            var productModels = products.Select(product => new ProductModel(product)).ToList();
            return View(productModels);
        }

        public IActionResult Details(int id)
        {
            var product = _productCollection.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            var productModel = new ProductModel(product);

            return View(productModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ID = productModel.ID,
                    CategoryID = productModel.CategoryID,
                    Name = productModel.Name,
                    ImageUrl = productModel.ImageUrl,
                    Price = productModel.Price,
                    Description = productModel.Description
                };

                _productCollection.AddProduct(product);

                return RedirectToAction(nameof(Index));
            }

            return View(productModel);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productCollection.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            var productModel = new ProductModel(product);

            return View(productModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductModel productModel)
        {
            if (id != productModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var product = _productCollection.GetProductByID(id);

                if (product == null)
                {
                    return NotFound();
                }

                product.ID = productModel.ID;
                product.Name = productModel.Name;
                product.ImageUrl = productModel.ImageUrl;
                product.Price = productModel.Price;
                product.Description = productModel.Description;

                _productCollection.EditProduct(product);

                return RedirectToAction(nameof(Index));
            }

            return View(productModel);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productCollection.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            var productModel = new ProductModel(product);

            return View(productModel);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductModel productModel)
        {
            var product = _productCollection.GetProductByID(productModel.ID);

            if (product == null)
            {
                return NotFound();
            }

            _productCollection.DeleteProduct(productModel.ID);
            return RedirectToAction(nameof(Index));
        }
    }
}