using BookwormWeb.Data;
using BookwormWeb.Models;
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

        public IActionResult Create()
        {
            return View();
        }
    }
}
