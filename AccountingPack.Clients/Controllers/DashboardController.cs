using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingPack.Data;
using AccountingPack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccountingPack.Clients.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepositoryService<Business> _businessService;
        private readonly IRepositoryService<LoginUser> _loginUser;

        public DashboardController(UserManager<ApplicationUser> userManager,
            IRepositoryService<Business> businessService,
            IRepositoryService<LoginUser> loginUser)
        {
            _userManager = userManager;
            _businessService = businessService;
            _loginUser = loginUser;
        }

        public IActionResult Index()
        {

            int id = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));

            LoginUser user = _loginUser.Detail(id);

            Business model = _businessService.List(b => b.Owner.Id == user.Id).FirstOrDefault();

            ViewBag.Email = user.UserName;

            return View(model);

        }

        public IActionResult Business()
        {

            int id = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));

            LoginUser user = _loginUser.Detail(id);

            Business model = _businessService.List(b => b.Owner.Id == user.Id).FirstOrDefault();

            return PartialView("_Business", model);

        }
    }
}