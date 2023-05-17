// using DAL.Interface;
// using Microsoft.AspNetCore.Mvc;
// using MvcArcheryWebshop.Models;
// using WebshopClassLibrary;
// using WebshopClassLibrary.Mapping;
//
// namespace MvcArcheryWebshop.Controllers
// {
//     public class CategoryController : Controller
//     {
//
//         private readonly CategoryCollection _categoryCollection;
//
//         public CategoryController(CategoryCollection categoryCollection)
//         {
//             _categoryCollection = categoryCollection;
//         }
//
//         // GET: Category
//         public IActionResult Index()
//         {
//             var categories = _categoryCollection.GetCategories();
//             return View(categories);
//         }
//
//         // GET: Category/Create
//         public IActionResult Create()
//         {
//             return View();
//         }
//
//         // POST: Category/Create
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public IActionResult Create(CategoryModel category)
//         {
//             if (ModelState.IsValid)
//             {
//                 _categoryCollection.AddCategory(category);
//                 return RedirectToAction(nameof(Index));
//             }
//
//             return View(category);
//         }
//
//         // GET: Category/Edit/5
//         public IActionResult Edit(int id)
//         {
//             CategoryModel category = _categoryCollection.GetCategoryById(id);
//             if (category == null)
//             {
//                 return NotFound();
//             }
//
//             return View(category);
//         }
//
//         // POST: Category/Edit/5
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public IActionResult Edit(int id, CategoryModel category)
//         {
//             if (id != category.ID)
//             {
//                 return NotFound();
//             }
//
//             if (ModelState.IsValid)
//             {
//                 _categoryCollection.UpdateCategory(category);
//                 return RedirectToAction(nameof(Index));
//             }
//
//             return View(category);
//         }
//
//         // GET: Category/Delete/5
//         public IActionResult Delete(int id)
//         {
//             CategoryModel category = _categoryCollection.GetCategoryById(id);
//             if (category == null)
//             {
//                 return NotFound();
//             }
//
//             return View(category);
//         }
//
//         // POST: Category/Delete/5
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public IActionResult DeleteConfirmed(int id)
//         {
//             _categoryCollection.DeleteCategory(id);
//             return RedirectToAction(nameof(Index));
//         }
//     }
// }
//TODO: add CRUD in something like shopping cart instead of category

