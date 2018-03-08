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
    public class CurrentAssetController : BaseController
    {

        private readonly IRepositoryService<CurrentAsset> _currentAsset;
        private readonly ILogger _logger;

        public CurrentAssetController(ICompositeViewEngine viewEngine,
            IRepositoryService<AccountOwner> businessOwner,
            UserManager<ApplicationUser> userManager,
            IRepositoryService<CurrentAsset> currentAsset,
            IRepositoryService<LoginUser> loginUser,
            ILoggerFactory loggerFactory)
            : base(viewEngine, businessOwner, userManager,loginUser)
        {
            _logger = loggerFactory.CreateLogger<CurrentAssetController>();
            _currentAsset = currentAsset;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// create current asset
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {

            ViewBag.BusinessId = BusinessId();

            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CurrentAsset model)
        {

            if (!ModelState.IsValid)
            {

                ViewBag.BusinessId = BusinessId();

                result.View = await RenderPartialViewToString("_Create", model);

            }
            else
            {

                _currentAsset.Create(model);
                _currentAsset.SaveChanges();

                result.Success = true;
                result.Redirect = Url.Action("Entity", "Dashboard");

            }

            return Json(result);

        }

        /// <summary>
        /// edit current asset
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {

            if (id == null)
                return BadRequest();

            CurrentAsset model = _currentAsset.Detail(id);

            if (model == null)
                return NotFound();

            return PartialView("_Edit", model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CurrentAsset model)
        {
            if (!ModelState.IsValid)
            {
                result.View = await RenderPartialViewToString("_Edit", model);
            }
            else
            {
                try
                {

                    _currentAsset.Edit(model);
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
        /// remove current asset
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {

            if (id == null)
                return BadRequest();

            CurrentAsset model = _currentAsset.Detail(id);

            if (model == null)
                return NotFound();

            return PartialView("_Delete", model);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(CurrentAsset model)
        {
            try
            {
                _currentAsset.Delete(model);
                _currentAsset.SaveChanges();

                result.Success = true;
                result.Redirect = Url.Action("Entity", "Dashboard");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Json(result);

        }

        public IActionResult List()
        {


            int businessId = BusinessId().Value;

            List<CurrentAsset> models = _currentAsset.List(ca => ca.BusinessId == businessId);

            return PartialView("_List", models);

        }

    }
}