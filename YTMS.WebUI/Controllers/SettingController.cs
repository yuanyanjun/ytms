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
            if (data == null)
                data = InitConfig();
            return JsonContent(data);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionExceptionHandler]
        public ActionResult SetSysConfig(SysConfigDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("config");

            dto.CreateBy = dto.LastModifyBy = CurrentAccount.Id.ToString();
            dto.CreateTime = dto.LastModifyTime = DateTime.Now;

            _sysConfigServer.Set(dto);

            return JsonContent(true);
        }


        private SysConfigDto InitConfig()
        {
            var userId = CurrentAccount.Id.ToString();
            var dt = DateTime.Now;
            var cfg = new SysConfigDto()
            {
                Proportion = 3,
                FixedLoss = 40,
                PlatformPoint = 15,
                FloorEarnings = 1600,
                RoomCoverMaxNum = 2,
                CreateBy = userId,
                LastModifyBy = userId,
                CreateTime = dt,
                LastModifyTime = dt
            };

            _sysConfigServer.Set(cfg);

            return cfg;
        }
    }
}