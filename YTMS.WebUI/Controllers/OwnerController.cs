using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using YTMS.BLL.Room;
namespace YTMS.WebUI.Controllers
{
    public class OwnerController : PlatformBaseController
    {
        IOwnerServer _ownerServer;
        public OwnerController()
        {
            _ownerServer = new OwnerServer();
        }
        [HttpGet, ActionExceptionHandler(ExceptionHandlerMethod.RedirectErrorPage)]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionExceptionHandler(ExceptionHandlerMethod.ReturnJson)]
        public ActionResult GetOwnerList(OwnerQueryFilter filter)
        {
            if (filter == null)
                filter = new OwnerQueryFilter() { PageIndex = 1, PageSize = 20 };

            var dataList = _ownerServer.List(filter);

            return JsonContent(new { Rows = dataList, TotalCount = filter.TotalCount });
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionExceptionHandler(ExceptionHandlerMethod.ReturnJson)]
        public ActionResult Save(OwnerDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new CustomException("业主姓名不能为空");

            if (string.IsNullOrWhiteSpace(dto.Phone))
                throw new CustomException("业主手机号不能为空");

            if (string.IsNullOrWhiteSpace(dto.CardNo))
                throw new CustomException("业主身份证号不能为空");

            if (string.IsNullOrWhiteSpace(dto.Sex))
                throw new CustomException("业主性别不能为空");

            dto.CreateBy = AccountName;
            dto.CreateTime = dto.LastModifyTime = DateTime.Now;
            if (dto.Id.HasValue)
            {
                _ownerServer.Edit(dto);
            }
            else
            {
                dto.Id = _ownerServer.Add(dto);
            }
            return JsonContent(dto);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionExceptionHandler(ExceptionHandlerMethod.ReturnJson)]
        public ActionResult Remove(long id)
        {
            _ownerServer.Deleted(id);
            return JsonContent(true);
        }
    }
}