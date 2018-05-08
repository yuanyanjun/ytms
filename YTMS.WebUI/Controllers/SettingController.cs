using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using YTMS.BLL.SysConfig;
namespace YTMS.WebUI.Controllers
{
    public class SettingController : PlatformBaseController
    {
        ISysConfigServer _sysConfigServer = null;
        public SettingController()
        {
            _sysConfigServer = new SysConfigServer();
        }
        [HttpGet, ActionExceptionHandler(ExceptionHandlerMethod.RedirectErrorPage)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, ActionExceptionHandler]
        public ActionResult GetSysConfig()
        {
            var data = _sysConfigServer.Get();

            return JsonContent(data);
        }
    }
}