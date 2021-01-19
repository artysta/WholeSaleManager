using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WholeSaleManager.DataAccess.Data;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using WholeSaleManager.Utility;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Admin + "," + StaticDetails.Role_Employee)]

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _unitOfWork.ApplicationUser.GetAll();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach(var user in users)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if(user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }

            }
            return Json(new { data = users });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(user => user.Id == id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "An error occured while Locking/Unlocking" });
            }
            if(objFromDb.LockoutEnd!=null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return Json(new { success = true, message = "The operation was successful" });

        }

        #endregion
    }
}