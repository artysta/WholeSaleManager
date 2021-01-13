using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WholeSaleManager.DataAccess.Data;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db
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

        #endregion
    }
}