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

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepositoryService<Business> _businessService;
        private readonly ILogger _logger;

        public BusinessController(ICompositeViewEngine viewEngine,
            ILoggerFactory loggerFactory,
            UserManager<ApplicationUser> userManager,
            IRepositoryService<Business> businessService)
            : base(viewEngine)
        {
            _userManager = userManager;
            _businessService = businessService;
            _logger = loggerFactory.CreateLogger<BusinessController>();

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
                try {

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

    }
}