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
    public class LongTermAssetController : BaseController
    {
        private readonly IRepositoryService<LongTermAsset> _longTermAssetService;
        private readonly ILogger _logger;

        public LongTermAssetController(ICompositeViewEngine viewEngine,
            IRepositoryService<AccountOwner> businessOwner,
            UserManager<ApplicationUser> userManager,
            IRepositoryService<LongTermAsset> longTermAssetService,
            IRepositoryService<LoginUser> loginUser,
            ILoggerFactory loggerFactory)

            : base(viewEngine,businessOwner, userManager, loginUser)
        {

            _longTermAssetService = longTermAssetService;
            _logger = loggerFactory.CreateLogger<BusinessController>();

        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// create long-term asset
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {


            ViewBag.BusinessId = BusinessId();

            return PartialView("_Create");

        }

        [HttpPost]
        public async Task<IActionResult> Create(LongTermAsset model)
        {

            if (!ModelState.IsValid)
            {

                ViewBag.BusinessId = BusinessId();

                result.View = await RenderPartialViewToString("_Create", model);

            }
            else
            {
                try
                {
                    _longTermAssetService.Create(model);
                    _longTermAssetService.SaveChanges();
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
        /// change long-term asset
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {

            if (id == null)
                return BadRequest();

            LongTermAsset model = _longTermAssetService.Detail(id);

            if (model == null)
                return NotFound();

            return PartialView("_Edit", model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(LongTermAsset model)
        {

            if (!ModelState.IsValid)
            {
                result.View = await RenderPartialViewToString("_Edit", model);
            }
            else
            {
                try
                {
                    _longTermAssetService.Edit(model);
                    _longTermAssetService.SaveChanges();

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
        /// delete long-term asset
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {

            if (id == null)
                return BadRequest();

            LongTermAsset model = _longTermAssetService.Detail(id);

            if (model == null)
                return NotFound();

            return PartialView("_Delete", model);

        }

        [HttpPost]
        public IActionResult Delete(LongTermAsset model)
        {
            try
            {

                _longTermAssetService.Delete(model);
                _longTermAssetService.SaveChanges();
                result.Success = true;
                result.Redirect = Url.Action("Entity", "Dashboard");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Json(result);

        }

        /// <summary>
        /// list of business related long-term assets
        /// </summary>
        /// <returns></returns>
        public IActionResult List()
        {

            int? businessId = BusinessId();

            List<LongTermAsset> models = _longTermAssetService.List(la => la.BusinessId == businessId);

            return PartialView("_List", models);

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
        public IActionResult RemDep()
        {
            return PartialView("_RemDep");
        }
    }
}