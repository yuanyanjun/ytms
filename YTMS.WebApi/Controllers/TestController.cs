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

        [HttpPost]
        public dynamic SetConfig(SysConfigDto opt)
        {

            if (opt == null)
                throw new ArgumentNullException("opt");

            var dt = DateTime.Now;
            opt.CreateBy = "yyj";
            opt.CreateTime = dt;
            opt.LastModifyBy = "yyj";
            opt.LastModifyTime = dt;

            _sysCofigSever.Set(opt);

            return true;
        }
    }
}
