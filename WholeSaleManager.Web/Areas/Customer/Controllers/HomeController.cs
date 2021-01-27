using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WholeSaleManager.Models.ViewModels;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using WholeSaleManager.Utility;
using Microsoft.AspNetCore.Http;


namespace WholeSaleManager.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork; 

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category,Manufacturer");
            

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if(claim != null)
            {
                var count = _unitOfWork.ShoppingCart.GetAll(
                   cart => cart.ApplicationUserId == claim.Value)
                   .ToList().Count();


                HttpContext.Session.SetInt32(StaticDetails.sessionShoppingCart, count);

            }
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var productFromDb = _unitOfWork.Product.
                GetFirstOrDefault(p => p.Id == id, includeProperties: "Category,Manufacturer");
            ShoppingCart cartObj = new ShoppingCart() 
            {
                Product=productFromDb,
                ProductId=productFromDb.Id
            };
            return View(cartObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart CartObj)
        {
            CartObj.Id = 0;
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                CartObj.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDatabase = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                    user => user.ApplicationUserId == CartObj.ApplicationUserId &&
                    user.ProductId == CartObj.ProductId,
                    includeProperties: "Product"
                    );
                if(cartFromDatabase == null)
                {
                    // no records in Db
                    _unitOfWork.ShoppingCart.Add(CartObj);
                }
                else
                {
                    cartFromDatabase.Count += CartObj.Count;
                    _unitOfWork.ShoppingCart.Update(cartFromDatabase);
                }
                _unitOfWork.Save();

                var count = _unitOfWork.ShoppingCart.GetAll(
                    cart => cart.ApplicationUserId == CartObj.ApplicationUserId)
                    .ToList().Count();


                HttpContext.Session.SetInt32(StaticDetails.sessionShoppingCart, count);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var productFromDb = _unitOfWork.Product.
                GetFirstOrDefault(p => p.Id == CartObj.ProductId, includeProperties: "Category,Manufacturer");
                ShoppingCart CartObject = new ShoppingCart()
                {
                    Product = productFromDb,
                    ProductId = productFromDb.Id
                };
                return View(CartObject);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
