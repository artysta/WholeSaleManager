using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using WholeSaleManager.Models.ViewModels;
using WholeSaleManager.Utility;

namespace WholeSaleManager.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<IdentityUser> _userManager;
        public ShoppingCartViewModel SCVM { get; set; }

        
        public CartController(IUnitOfWork unitOfWork, IEmailSender emailSender, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            SCVM = new ShoppingCartViewModel()
            {
                OrderHeader = new OrderHeader(),
                Carts = _unitOfWork.ShoppingCart.GetAll(
                    u => u.ApplicationUserId == claim.Value,
                    includeProperties: "Product")
        };

            SCVM.OrderHeader.OrderTotal = 0;
            SCVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.
                GetFirstOrDefault(u => u.Id == claim.Value,
                includeProperties: "Company");

            foreach(var cart in SCVM.Carts)
            {
                cart.Price = StaticDetails.GetTotalPrice(
                    cart.Count, cart.Product.Price, cart.Product.Price50, cart.Product.Price100);
                SCVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }

            return View(SCVM);
        }
    }
}
