using Bookworm.DataAccess;
using Bookworm.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookwormWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDBContext db;

        public CategoryController(AppDBContext db)
        {
            this.db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = db.Categories;
            return View(objCategoryList);
        }

        // GET method 
        public IActionResult Create()
        {
            return View();
        }

        // POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            
            if(ModelState.IsValid)
            {
                this.db.Add(obj);
                this.db.SaveChanges();
                TempData["success"] = "Created category successfuly";
                return RedirectToAction("Index");
            }

            return View(obj);
            
        }

        // GET method 
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDBbyID = this.db.Categories.Find(id);

            if(categoryFromDBbyID == null)
            {
                return NotFound();
            }
            return View(categoryFromDBbyID);
        }

        // POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                this.db.Update(obj);
                this.db.SaveChanges();
                TempData["success"] = "Updated category successfuly";
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        // GET method 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDBbyID = this.db.Categories.Find(id);

            if (categoryFromDBbyID == null)
            {
                return NotFound();
            }
            return View(categoryFromDBbyID);
        }

        // POST method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = this.db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            this.db.Remove(obj);
            this.db.SaveChanges();
            TempData["success"] = "Deleted category successfuly";
            return RedirectToAction("Index");

        }
    }
}
