using Bookworm.DataAccess;
using Bookworm.DataAccess.Repository.IRepository;
using Bookworm.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookwormWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
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

            var categoryFromDBbyID = _unitOfWork.Category.GetFirstOrDefault(item=>item.ID == id);

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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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

            var categoryFromDBbyID = _unitOfWork.Category.GetFirstOrDefault(item => item.ID == id);

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

            var obj = _unitOfWork.Category.GetFirstOrDefault(item => item.ID == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Deleted category successfuly";
            return RedirectToAction("Index");

        }
    }
}
