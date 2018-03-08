using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingPack.Data;
using AccountingPack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace AccountingPack.Clients.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly IRepositoryService<Business> _businessService;
        private readonly IRepositoryService<AccountBaseEntitie> _entityService;

        public DashboardController(ICompositeViewEngine viewEngine,
            UserManager<ApplicationUser> userManager,
            IRepositoryService<Business> businessService,
            IRepositoryService<LoginUser> loginUser,
            IRepositoryService<AccountOwner> businessOwner,
            IRepositoryService<AccountBaseEntitie> entityService)
            : base(viewEngine,businessOwner, userManager, loginUser)
        {
            _businessService = businessService;
            _entityService = entityService;
        }

        public IActionResult Index()
        {

            AccountOwner owner = BusinessOwner();

            if (owner == null)
                return View();

            return View(owner.Business);

        }

        /// <summary>
        /// business dashboard
        /// </summary>
        /// <returns></returns>
        public IActionResult Business()
        {

            AccountOwner owner = BusinessOwner();

            return PartialView("_Business", owner.Business);

        }

        /// <summary>
        /// entity dashboard
        /// </summary>
        /// <returns></returns>
        public IActionResult Entity()
        {

            AccountOwner owner = BusinessOwner();

            List<AccountBaseEntitie> models = _entityService.List(m=>m.BusinessId == owner.BusinessId);

            return PartialView("_Entities", models);

        }
    }
}