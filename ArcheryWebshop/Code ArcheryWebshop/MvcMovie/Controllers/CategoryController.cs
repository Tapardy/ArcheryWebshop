using Microsoft.AspNetCore.Mvc;
using DataLayer;

namespace MvcArcheryWebshop.Controllers
{
    public class CategoryController : Controller
    {
        private List<string> _bowType = new List<string>();
        Database _database = new Database();

        // GET: Category

        public ActionResult Index()
        {
            _database.DataValues(_bowType);
            // //catch exeption ex
            return View(_bowType);

        }
    }
}
//TODO: add CRUD in something like shopping cart instead of category