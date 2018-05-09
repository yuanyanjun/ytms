using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YTMS.WebUI.Controllers
{
    public class AccountController : PlatformBaseController
    {
        [HttpGet, ActionExceptionHandler(ExceptionHandlerMethod.RedirectErrorPage)]
        public ActionResult Index()
        {
            return View();
        }
    }
}