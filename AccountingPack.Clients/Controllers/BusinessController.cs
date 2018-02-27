using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingPack.Data;
using AccountingPack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace AccountingPack.Clients.Controllers
{
    public class BusinessController : BaseController
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepositoryService<Business> _businessService;

        public BusinessController(ICompositeViewEngine viewEngine,
            UserManager<ApplicationUser> userManager,
            IRepositoryService<Business> businessService)
            : base(viewEngine)
        {
            _userManager = userManager;
            _businessService = businessService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Business model)
        {

            if (!ModelState.IsValid)
            {
                result.View = await RenderPartialViewToString("_Create", model);
            }
            else
            {
                result.Success = true;
                result.Redirect = Url.Action("Business", "Dashboard");
            }

            return Json(result);

        }

    }
}