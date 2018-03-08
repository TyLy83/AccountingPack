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
using Microsoft.Extensions.Logging;

namespace AccountingPack.Clients.Controllers
{
    [Authorize]
    public class EntitiesController : BaseController
    {

        private readonly IRepositoryService<AccountBaseEntitie> _entitieService;
        private readonly IRepositoryService<AccountOwner> _businessOwner;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepositoryService<CurrentAsset> _currentAsset;
        private readonly ILogger _logger;

        public EntitiesController(ICompositeViewEngine viewEngine,
            IRepositoryService<AccountBaseEntitie> entitieService,
            IRepositoryService<AccountOwner> businessOwner,
            UserManager<ApplicationUser> userManager,
            IRepositoryService<CurrentAsset> currentAsset,
            ILoggerFactory loggerFactory)
            : base(viewEngine)
        {
            _entitieService = entitieService;
            _businessOwner = businessOwner;
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<BusinessController>();
            _currentAsset = currentAsset;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create Current Asset
        /// </summary>
        /// <returns></returns>
        public IActionResult CurrentAsset()
        {

            int id = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));

            ViewBag.BusinessId = _businessOwner.Detail(id)
                                               .BusinessId;

            return PartialView("_CurrentAsset");

        }

        [HttpPost]
        public async Task<IActionResult> CurrentAsset(CurrentAsset model)
        {

            if (!ModelState.IsValid)
            {
                result.View = await RenderPartialViewToString("_CurrentAsset", model);
            }
            else
            {
                try
                {
                    //_entitieService.Create(model);
                    //_entitieService.SaveChanges();
                    _currentAsset.Create(model);
                    _currentAsset.SaveChanges();

                    result.Success = true;
                    result.Redirect = Url.Action("Entity", "Dashboard");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return Json(result);
        }

        /// <summary>
        /// create long term asset
        /// </summary>
        /// <returns></returns>
        public IActionResult LongTermAsset()
        {

            int id = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));

            ViewBag.BusinessId = _businessOwner.Detail(id)
                                               .BusinessId;

            return PartialView("_LongTermAsset");

        }

        [HttpPost]
        public async Task<IActionResult> LongTermAsset(LongTermAsset model)
        {
            if (!ModelState.IsValid)
            {
                result.View = await RenderPartialViewToString("_LongTermAsset", model);

            }
            else
            {
                try
                {
                    _entitieService.Create(model);
                    _entitieService.SaveChanges();
                    result.Success = true;
                    result.Redirect = Url.Action("Entity", "Dashboard");

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return Json(result);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult AddDep()
        {
            return PartialView("_AddDep");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult RemoveDep()
        {
            return PartialView("_RemoveDep");
        }

    }
}