using Bookworm.DataAccess;
using Bookworm.DataAccess.Repository.IRepository;
using Bookworm.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookwormWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll();
            return View(objProductList);
        }

        // GET method 
        public IActionResult Upsert(int? id)
        {
            Product product = new();
            if (id == null || id == 0)
            {
                // create product
                return View(product);
            } else
            {
                // update product
            }

            
            return View(product);
        }

        // POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Updated product successfuly";
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

            var productFromDBbyID = _unitOfWork.Product.GetFirstOrDefault(item => item.Id == id);

            if (productFromDBbyID == null)
            {
                return NotFound();
            }
            return View(productFromDBbyID);
        }

        // POST method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _unitOfWork.Product.GetFirstOrDefault(item => item.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Deleted product successfuly";
            return RedirectToAction("Index");

        }
    }
}
