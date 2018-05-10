using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using YTMS.BLL.Account;
using YTMS.Common.Core;

namespace YTMS.WebUI.Controllers
{
    public class LoginController : BaseController
    {
        IAccountServer _accountServer;
        public LoginController()
        {
            _accountServer = new AccountServer();
        }
        [HttpGet, ActionExceptionHandler(ExceptionHandlerMethod.RedirectErrorPage)]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionExceptionHandler(ExceptionHandlerMethod.ReturnJson)]
        public ActionResult SignIn(string account, string password)
        {
            if (string.IsNullOrWhiteSpace(account))
                throw new Exception("账号不能为空");
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("密码不能为空");

            account = account.Trim();

            try
            {
                var userInfo = _accountServer.Get(account);
                if (userInfo != null && userInfo.Password == password)
                {
                    Session[ConstDefined.SessionKey] = userInfo;
                    var sessinId = StringExt.Base64Encode(userInfo.Id.ToString(), null);
                    Response.Cookies.Add(new HttpCookie(ConstDefined.CookieKey, sessinId));
                }
                else
                {
                    throw new CustomException("登录失败。账号不存在或密码不正确");
                }
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }

            return JsonContent(true);
        }
    }
}