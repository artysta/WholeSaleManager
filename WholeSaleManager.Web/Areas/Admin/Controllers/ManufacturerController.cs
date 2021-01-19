using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using WholeSaleManager.Utility;

namespace BulkyBook.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Admin + "," + StaticDetails.Role_Employee)]

    public class ManufacturerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManufacturerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Manufacturer manufacturer = new Manufacturer();
            if (id == null)
            {
                return View(manufacturer);
            }

            manufacturer = _unitOfWork.Manufacturer.Get(id.GetValueOrDefault());
            
            if (manufacturer == null)
            {
                return NotFound();
            }
            
            return View(manufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                if (manufacturer.Id == 0)
                {
                    _unitOfWork.Manufacturer.Add(manufacturer);

                }
                else
                {
                    _unitOfWork.Manufacturer.Update(manufacturer);
                }

                _unitOfWork.Save();
                
                return RedirectToAction(nameof(Index));
            }

            return View(manufacturer);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Manufacturer.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Manufacturer.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting the manufacturer!" });
            }

            _unitOfWork.Manufacturer.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "You have successfully removed the manufacturer!" });
        }

        #endregion
    }
}