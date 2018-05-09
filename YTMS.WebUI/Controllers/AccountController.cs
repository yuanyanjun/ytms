using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using YTMS.BLL.Account;
namespace YTMS.WebUI.Controllers
{
    public class AccountController : PlatformBaseController
    {
        IAccountServer _accountServer = null;
        public AccountController()
        {
            _accountServer = new AccountServer();
        }
        [HttpGet, ActionExceptionHandler(ExceptionHandlerMethod.RedirectErrorPage)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionExceptionHandler(ExceptionHandlerMethod.ReturnJson)]
        public ActionResult GetList(AdminQueryFilter filter)
        {
            if (filter == null)
                filter = new AdminQueryFilter() { PageIndex = 1, PageSize = 20 };

            var dataList = _accountServer.List(filter);

            return JsonContent(new { Rows = dataList, TotalCount = filter.TotalCount });
        }

        [HttpPost, ActionExceptionHandler(ExceptionHandlerMethod.ReturnJson)]
        public ActionResult Save(AdminDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            dto.CreateBy = SessionUser.Account;
            dto.CreateTime = dto.LastModifyTime = DateTime.Now;

            if (!dto.Id.HasValue)
            {
                dto.Id = _accountServer.Add(dto);
            }
            else
            {
                _accountServer.Edit(dto);
            }
            return JsonContent(dto);
        }
    }
}