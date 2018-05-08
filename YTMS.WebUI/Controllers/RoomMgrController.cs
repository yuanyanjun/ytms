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
        public ActionResult GetList()
        {
            var data = _roomTypeServer.List();

            return JsonContent(data);
        }
    }
}