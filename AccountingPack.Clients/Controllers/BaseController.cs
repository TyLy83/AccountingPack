using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AccountingPack.Data;
using AccountingPack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;

namespace AccountingPack.Clients.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

        protected ResultModel result;
        private readonly ICompositeViewEngine _viewEngine;
        private readonly IRepositoryService<AccountOwner> _businessOwner;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepositoryService<LoginUser> _loginUser;

        public BaseController(ICompositeViewEngine viewEngine,
            IRepositoryService<AccountOwner> businessOwner,
            UserManager<ApplicationUser> userManager,
            IRepositoryService<LoginUser> loginUser)
        {
            _viewEngine = viewEngine;

            result = new ResultModel()
            {
                Success = false,
                View = string.Empty,
                Redirect = string.Empty
            };

            _businessOwner = businessOwner;
            _userManager = userManager;
            _loginUser = loginUser;

        }

        public async Task<string> RenderPartialViewToString(string viewName, object model)
        {

            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {

                ViewEngineResult viewResult =
                    _viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }

        public int? BusinessId()
        {
            int id = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));

            int? businessId = _businessOwner.Detail(id)
                                           .BusinessId;
            return businessId;
        }

        public AccountOwner BusinessOwner()
        {

            int id = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));

            return _businessOwner.Detail(id);

        }

        public LoginUser LoginUser()
        {
            int id = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));

            return _loginUser.Detail(id);
        }
    }
}