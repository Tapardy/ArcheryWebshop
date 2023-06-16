using DAL;
using Microsoft.AspNetCore.Mvc;
using MvcArcheryWebshop.Models;
using WebshopClassLibrary;
using WebshopClassLibrary.Mappers;

namespace MvcArcheryWebshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        private readonly CategoryProductService _categoryProductService;

        public ProductController()
        {
            _productService = new ProductService(new ProductDAL());
            _categoryService = new CategoryService(new CategoryDAL());
            _categoryProductService = new CategoryProductService(new CategoryProductDAL());
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            var productModels = products.Select(product => new ProductModel(product)).ToList();
            return View(productModels);
        }

        public IActionResult Details(int id)
        {
            var product = _productService.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            var productModel = new ProductModel(product);

            //retrieve the category id for the product
            var categoryIds = _categoryProductService.GetCategoryIdsForProduct(id);

            //retrieve the category names based on the id
            var categories = _categoryService.GetCategoriesByIds(categoryIds);

            //assign the category names to the product model
            productModel.Categories = categories;

            return View(productModel);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var categories = _categoryService.GetAllCategories();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel productModel, int[] SelectedCategoryIds)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ID = productModel.ID,
                    Name = productModel.Name,
                    ImageUrl = productModel.ImageUrl,
                    Price = productModel.Price,
                    Description = productModel.Description
                };

                _productService.AddProduct(product);

                //assign selected categories to the product
                if (SelectedCategoryIds != null)
                {
                    foreach (var categoryId in SelectedCategoryIds)
                    {
                        _categoryProductService.AddCategoryToProduct(categoryId, product.ID);
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            //iff the model state is not valid, retrieve the categories again and pass them to the view
            var categories = _categoryService.GetAllCategories();
            ViewBag.Categories = categories;

            return View(productModel);
        }


        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _productService.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            var productModel = new ProductModel(product);

            //retrieve all categories
            var allCategories = _categoryService.GetAllCategories();
            ViewBag.AllCategories = allCategories;

            //retrieve the category id for the product
            var categoryIds = _categoryProductService.GetCategoryIdsForProduct(id);

            //assign the selected category id to the model
            productModel.SelectedCategoryIds = categoryIds;

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
                var product = _productService.GetProductByID(id);

                if (product == null)
                {
                    return NotFound();
                }

                product.Name = productModel.Name;
                product.ImageUrl = productModel.ImageUrl;
                product.Price = productModel.Price;
                product.Description = productModel.Description;

                _productService.EditProduct(product);

                //update the categories of the product
                _categoryProductService.RemoveCategoriesFromProduct(id);

                if (productModel.SelectedCategoryIds != null)
                {
                    foreach (var categoryId in productModel.SelectedCategoryIds)
                    {
                        _categoryProductService.AddCategoryToProduct(categoryId, product.ID);
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            //if the model state is not valid, retrieve the categories again and pass them to the view
            var allCategories = _categoryService.GetAllCategories();
            ViewBag.AllCategories = allCategories;

            return View(productModel);
        }


        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productService.GetProductByID(id);

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
            _categoryProductService.RemoveCategoriesFromProduct(productModel.ID);
            _productService.DeleteProduct(productModel.ID);
            return RedirectToAction("Index");
        }
    }
}