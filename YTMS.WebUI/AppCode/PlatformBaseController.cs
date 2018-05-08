using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YTMS.BLL.Account;
using YTMS.Common.Core;
namespace YTMS.WebUI
{
    public class PlatformBaseController : BaseController
    {
        protected delegate void OnCreateSession_Delegate();
        const string session_key = "session_user";
        AccountSessionInfo _sessionuser = null;
        string _gourl;
        Exception _ex;
        IAccountServer adminServer = new AccountServer();
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {

            try
            {
                base.Initialize(requestContext);

                var req = requestContext.HttpContext.Request;

                //登录
                if (!IsAjaxRequest)
                {
                    var sessionid = req.QueryString["sessionid"];
                    sessionid = StringExt.Base64Encode("1", null);
                    if (!string.IsNullOrWhiteSpace(sessionid))
                    {
                        CreateSession(sessionid);
                    }

                    
                }

                //保持会话
                if (SessionUser == null)
                {
                    var session_id = SessionId;
                    if (!(!string.IsNullOrWhiteSpace(session_id) && CreateSession(session_id)))
                    {
                        if (IsAjaxRequest)
                            throw new CustomException("当前用户已掉线，请重新登录");
                        _gourl = System.Configuration.ConfigurationManager.AppSettings.Get("CurrentWebBaseUrl").TrimEnd('/') + "/Login";
                    }

                }
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.CurrentAccount = SessionUser;
            base.OnResultExecuting(filterContext);
        }

        protected bool IsLogin
        {
            get
            {
                return _sessionuser != null;
            }
        }

        protected AccountSessionInfo SessionUser
        {
            get
            {
                if (_sessionuser == null)
                {
                    _sessionuser = (AccountSessionInfo)Session[session_key];
                }

                return _sessionuser;
            }
            private set
            {
                Session[session_key] = value;
                _sessionuser = value;
            }
        }

        protected string SessionId
        {
            get
            {
                var cookie = Request.Cookies["session_id"];
                return cookie == null ? null : cookie.Value;
            }
            private set
            {

                Response.Cookies.Remove("session_id");
                Request.Cookies.Remove("session_id");
                Response.Cookies.Add(new HttpCookie("session_id", value));
            }
        }

        protected override IActionInvoker CreateActionInvoker()
        {
            return new CustomActionInvoker(_gourl, _ex, this.IsAjaxRequest);
        }

        protected OnCreateSession_Delegate OnCreateSession = null;

        bool CreateSession(string sessionid)
        {
            long id;
            var str_id = StringExt.Base64Decode(sessionid, null);
            Int64.TryParse(str_id, out id);
            var user = adminServer.Get((long)id);//UserDAL.Instance.Get(id);
            if (user != null)
            {
                SessionUser = user.MapTo<AccountSessionInfo>();
                //将SessionID写到客户端，以备会话过期时再用它保持会话
                SessionId = sessionid;
                if (OnCreateSession != null)
                    OnCreateSession.Invoke();
                return true;
            }

            return false;
        }
    }
    /// <summary>
    /// 自定义Aaction调用器
    /// 自所有Action调用之前处理登录跳转和初始化异常
    /// </summary>
    public class CustomActionInvoker : ControllerActionInvoker
    {
        string _goUrl;
        Exception _error;
        bool _isAjaxReq;


        public CustomActionInvoker(string url, Exception error, bool isAjaxReq)
            : base()
        {
            _goUrl = url;
            _error = error;
            _isAjaxReq = isAjaxReq;
        }

        protected override ActionResult InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary<string, object> parameters)
        {
            object returnValue;

            if (!controllerContext.IsChildAction)
            {
                if (!string.IsNullOrWhiteSpace(_goUrl))
                    returnValue = new RedirectResult(_goUrl);
                else if (_error != null)
                {
                    if (_isAjaxReq)
                    {
                        controllerContext.HttpContext.Response.ContentType = "application/json";
                        returnValue = new CustomJsonResult(_error);
                    }
                    else
                    {

                        var v = new ViewResult();
                        v.ViewName = "Error";
                        v.ViewBag.ErrorMsg = _error.Message;
                        returnValue = v;
                    }

                }
                else
                    returnValue = actionDescriptor.Execute(controllerContext, parameters);

            }
            else
            {
                returnValue = actionDescriptor.Execute(controllerContext, parameters);
            }

            ActionResult result = CreateActionResult(controllerContext, actionDescriptor, returnValue);
            return result;
        }
    }

}