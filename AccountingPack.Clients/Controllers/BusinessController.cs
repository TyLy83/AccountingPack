using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingPack.Data;
using AccountingPack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;

namespace AccountingPack.Clients.Controllers
{
    public class BusinessController : BaseController
    {

        private readonly IRepositoryService<Business> _businessService;
        private readonly ILogger _logger;

        public BusinessController(ICompositeViewEngine viewEngine,
            ILoggerFactory loggerFactory,
            UserManager<ApplicationUser> userManager,
            IRepositoryService<Business> businessService,
            IRepositoryService<AccountOwner> businessOwner,
            IRepositoryService<LoginUser> loginUser)
            : base(viewEngine, businessOwner, userManager, loginUser)
        {
            _businessService = businessService;
            _logger = loggerFactory.CreateLogger<BusinessController>();
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create business
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {

            ViewBag.LoginUser = LoginUser();

            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Business model)
        {

            if (!ModelState.IsValid)
            {

                result.View = await RenderPartialViewToString("_Create", model);

            }
            else
            {
                try
                {

                    _businessService.Create(model);
                    _businessService.SaveChanges();

                    result.Success = true;
                    result.Redirect = Url.Action("Business", "Dashboard");

                }
                catch (Exception ex)
                {
                    result.View = await RenderPartialViewToString("_Create", model);
                    _logger.LogError(ex.Message);
                }
            }

            return Json(result);

        }

        /// <summary>
        /// Business details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                _logger.LogError("Business Id Is Null");
                return BadRequest();
            }

            Business model = _businessService.Detail(id);

            if (model == null)
            {
                _logger.LogError("Business Not Found");
                return NotFound();

            }

            return PartialView("_Details", model);

        }

        /// <summary>
        /// Edit a business
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {

            ViewBag.LoginUser = LoginUser();

            if (id == null)
                return BadRequest();

            Business model = _businessService.Detail(id);

            if (model == null)
                return NotFound();

            return PartialView("_Edit", model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Business model)
        {

            if (!ModelState.IsValid)
            {

                result.View = await RenderPartialViewToString("_Edit", model);

            }
            else
            {
                try
                {

                    _businessService.Edit(model);
                    _businessService.SaveChanges();

                    // everything is fine if we got this far
                    result.Success = true;
                    result.Redirect = Url.Action("Business", "Dashboard");

                }
                catch (Exception ex)
                {
                    result.View = await RenderPartialViewToString("_Edit", model);
                    _logger.LogError(ex.Message);
                }
            }

            return Json(result);

        }
    }
}