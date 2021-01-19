using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using WholeSaleManager.Utility;

namespace BulkyBook.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                return View(category);
            }

            category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            
            if (category == null)
            {
                return NotFound();
            }
            
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);

                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }

                _unitOfWork.Save();
                
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting the category!" });
            }

            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "You have successfully removed the category!" });
        }

        #endregion
    }
}