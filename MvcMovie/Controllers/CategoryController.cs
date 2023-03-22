using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace MvcArcheryWebshop.Controllers
{
    public class Secrets
    {
        public string ConnectionString { get; set; }
    }
    public class CategoryController : Controller
    {
        private string connectionString;
        // GET: Category
        public ActionResult Index()
        {
            string secretsPath = "/Users/yorischarnigg/.microsoft/usersecrets/b57ad032-2a18-4724-b7c0-85fe635013df/secrets.json";
            string secretsJson = System.IO.File.ReadAllText(secretsPath);
            Secrets secrets = JsonSerializer.Deserialize<Secrets>(secretsJson);
            connectionString = secrets.ConnectionString;
            //data from db
            //ideally different applications
            //bv list maken en dan deze list returnen
            //code in class in library
            // Create a new database connection:
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            
            cnn.Open();
            
            // SqlCommand command = new SqlCommand(
            //     "SELECT * FROM Category;");
            // SqlDataReader reader = command.ExecuteReader();
            // while (reader.Read())
            // {
            //     
            // }
            cnn.Close();
            //catch exeption ex
            return View();
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}