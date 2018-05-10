using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YTMS.WebUI.Controllers
{
    public class LoginOutController : Controller
    {
        [HttpGet, ActionExceptionHandler(ExceptionHandlerMethod.RedirectErrorPage)]
        public ActionResult Index()
        {
            Session.Remove(ConstDefined.SessionKey);
            Request.Cookies.Remove(ConstDefined.CookieKey);
            Response.Cookies.Remove(ConstDefined.CookieKey);

            var cookie = new HttpCookie(ConstDefined.CookieKey);
            cookie.Expires = DateTime.Now.AddDays(-10);
            Response.Cookies.Add(cookie);
            return Redirect("~/Login/Index");
        }
    }
}