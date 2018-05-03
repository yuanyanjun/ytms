using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using YTMS.BLL.SysConfig;
namespace YTMS.WebApi.Controllers
{
    public class TestController : ApiController
    {
        ISysConfigServer _sysCofigSever;
        public TestController()
        {
            _sysCofigSever = new SysConfigServer();
        }

        [HttpGet]
        public dynamic GetConfig()
        {
            return _sysCofigSever.Get();
        }
    }
}
