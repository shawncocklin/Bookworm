using Bookworm.DataAccess;
using Bookworm.DataAccess.Repository.IRepository;
using Bookworm.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookwormWeb.Areas.Admin.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        // GET method 
        public IActionResult Create()
        {
            return View();
        }

        // POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Created cover type successfuly";
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        // GET method 
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var coverTypeFromDBbyID = _unitOfWork.CoverType.GetFirstOrDefault(item => item.Id == id);

            if (coverTypeFromDBbyID == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDBbyID);
        }

        // POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Updated cover type successfuly";
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

            var coverTypeFromDBbyID = _unitOfWork.CoverType.GetFirstOrDefault(item => item.Id == id);

            if (coverTypeFromDBbyID == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDBbyID);
        }

        // POST method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _unitOfWork.CoverType.GetFirstOrDefault(item => item.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Deleted category successfuly";
            return RedirectToAction("Index");

        }
    }
}
