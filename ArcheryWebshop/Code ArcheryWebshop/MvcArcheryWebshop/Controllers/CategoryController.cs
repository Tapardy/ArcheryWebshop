 using DAL;
 using DAL.Interface;
 using Microsoft.AspNetCore.Mvc;
 using MvcArcheryWebshop.Models;
 using WebshopClassLibrary;
 using WebshopClassLibrary.Mappers;

 namespace MvcArcheryWebshop.Controllers
 {
     public class CategoryController : Controller
     {

         private readonly CategoryService _categoryDal;

         public CategoryController()
         {
             _categoryDal = new CategoryService(new CategoryDAL());
         }

         // GET: Category
         public IActionResult Index()
         {
             var categories = _categoryDal.GetAllCategories();
             return View(categories);
         }

     }
 }