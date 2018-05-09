using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using YTMS.BLL.Room;
namespace YTMS.WebUI.Controllers
{
    public class RoomMgrController : PlatformBaseController
    {
        IRoomTypeServer _roomTypeServer = null;
        public RoomMgrController()
        {
            _roomTypeServer = new RoomTypeServer();
        }
        [HttpGet, ActionExceptionHandler(ExceptionHandlerMethod.RedirectErrorPage)]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet, ActionExceptionHandler(ExceptionHandlerMethod.RedirectErrorPage)]
        public ActionResult RoomType()
        {
            return View();
        }
        [HttpGet, ActionExceptionHandler(ExceptionHandlerMethod.ReturnJson)]
        public ActionResult GetRoomTypeList()
        {
            var data = _roomTypeServer.List();

            return JsonContent(data);
        }

        [HttpPost, ActionExceptionHandler(ExceptionHandlerMethod.ReturnJson)]
        public ActionResult SaveRoomType(RoomTypeDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            var isAdd = !dto.Id.HasValue;

            if (_roomTypeServer.ExistName(dto.Name, dto.Id))
                throw new CustomException("房型名称已存在");

            dto.CreateBy = SessionUser.Account;
            dto.CreateTime = dto.LastModifyTime = DateTime.Now;

            if (isAdd)
                dto.Id = _roomTypeServer.Add(dto);
            else
                _roomTypeServer.Edit(dto);
            return JsonContent(dto);
        }

        [HttpPost, ActionExceptionHandler(ExceptionHandlerMethod.ReturnJson)]
        public ActionResult DeleteRoomType(int id)
        {
            _roomTypeServer.Remove(id);

            return JsonContent(true);
        }
    }
}