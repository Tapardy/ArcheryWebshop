using DAL;
using Microsoft.AspNetCore.Mvc;

namespace MvcArcheryWebshop.Controllers
{
    public class CategoryController : Controller
    {

        //objecten doorgeven met DTO
        // GET: Category

        public ActionResult Index()
        {
            return View();

        }
    }
}
//TODO: add CRUD in something like shopping cart instead of category