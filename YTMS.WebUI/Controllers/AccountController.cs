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

            if (string.IsNullOrWhiteSpace(dto.Account))
                throw new CustomException("登录账号不能为空");
            if (!dto.Id.HasValue)
            {
                if (string.IsNullOrWhiteSpace(dto.Password))
                    throw new CustomException("登录密码不能为空");
            }
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new CustomException("真实姓名不能为空");

            if (string.IsNullOrWhiteSpace(dto.Sex))
                throw new CustomException("性别不能为空");

            if (string.IsNullOrWhiteSpace(dto.Phone))
                throw new CustomException("手机号码不能为空");

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

        [HttpPost, ActionExceptionHandler(ExceptionHandlerMethod.ReturnJson)]
        public ActionResult Remove(long id)
        {

            if (id == SessionUser.Id)
                throw new CustomException("当前用户正处于登录状态，删除失败");

            _accountServer.Remove(id);

            return JsonContent(true);
        }

        [HttpPost, ActionExceptionHandler(ExceptionHandlerMethod.ReturnJson)]
        public ActionResult ReSetPassword(long id,string password)
        {

            if (string.IsNullOrWhiteSpace(password))
                throw new CustomException("密码不能为空");

            _accountServer.EditPassword(id,password);

            return JsonContent(true);
        }
    }
}