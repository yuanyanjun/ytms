﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YTMS.WebUI
{
    public class CustomJsonResult : JsonResult
    {
        private AjaxRequestErrorInfo _errorInfo;
        private Boolean _iserror = false;
        private object _obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">要输出的对象</param>
        public CustomJsonResult(object obj)
        {
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            if (obj is CustomException)
            {
                var error = obj as CustomException;
                _errorInfo = new AjaxRequestErrorInfo { errorCode = error.ErrorCode, errorType = error.ExceptionType, message = error.Message };
                _iserror = true;
            }
            else if (obj is System.Exception)
            {
                _errorInfo = new AjaxRequestErrorInfo { message = (obj as Exception).Message };
                _iserror = true;
            }
            else
            {
                _iserror = false;
                _obj = obj;
            }

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        public CustomJsonResult(string errorMsg)
            : this(errorMsg, -1, "Unkonw")
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        /// <param name="errorCode">错误码</param>
        public CustomJsonResult(string errorMsg, int errorCode)
            : this(errorMsg, errorCode, "Unkonw")
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="exception">异常对象</param>
        public CustomJsonResult(CustomException exception)
            : this(exception.Message, exception.ErrorCode, exception.ExceptionType)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        /// <param name="errorCode">错误码</param>
        /// <param name="exceptionType">异常类型</param>
        public CustomJsonResult(string errorMsg, int errorCode, string exceptionType)
        {
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            _errorInfo = new AjaxRequestErrorInfo { errorCode = errorCode, errorType = exceptionType, message = errorMsg };
            _iserror = true;
        }

        /// <summary>
        /// 执行结果
        /// </summary>
        /// <param name="context">控制器上下文</param>
        public override void ExecuteResult(ControllerContext context)
        {

            AjaxRequestResult obj = null;
            if (_obj is AjaxRequestResult)
            {
                obj = _obj as AjaxRequestResult;
            }
            else
            {
                obj = new AjaxRequestResult();
                if (!_iserror)
                {
                    obj.value = _obj;
                }
                else
                {
                    obj.error = _errorInfo;
                }
            }

            var req = context.HttpContext.Request;
            var resp = context.HttpContext.Response;
            var setting = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            var callback = req.QueryString["jsoncallback"];
            if (String.IsNullOrWhiteSpace(callback))
            {
                callback = req.QueryString["callback"];
            }

            if (String.IsNullOrWhiteSpace(callback))
            {
                resp.Write(JsonConvert.SerializeObject(obj, setting));
            }
            else //jsonp
            {

                resp.Write(callback);
                resp.Write("(");
                resp.Write(JsonConvert.SerializeObject(obj, setting));
                resp.Write(");");

            }


        }

    }
    public class CustomJsonResult<T> : JsonResult
    {
        private AjaxRequestErrorInfo _errorInfo;
        private Boolean _iserror = false;
        private T _obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">要输出的对象</param>
        public CustomJsonResult(T obj)
        {
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            if (obj is CustomException)
            {
                var error = obj as CustomException;
                _errorInfo = new AjaxRequestErrorInfo { errorCode = error.ErrorCode, errorType = error.ExceptionType, message = error.Message };
                _iserror = true;
            }
            else if (obj is System.Exception)
            {
                _errorInfo = new AjaxRequestErrorInfo { message = (obj as Exception).Message };
                _iserror = true;
            }
            else
            {
                _iserror = false;
                _obj = obj;
            }

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        public CustomJsonResult(string errorMsg)
            : this(errorMsg, -1, "Unkonw")
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        /// <param name="errorCode">错误码</param>
        public CustomJsonResult(string errorMsg, int errorCode)
            : this(errorMsg, errorCode, "Unkonw")
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="exception">异常对象</param>
        public CustomJsonResult(CustomException exception)
            : this(exception.Message, exception.ErrorCode, exception.ExceptionType)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        /// <param name="errorCode">错误码</param>
        /// <param name="exceptionType">异常类型</param>
        public CustomJsonResult(string errorMsg, int errorCode, string exceptionType)
        {
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            _errorInfo = new AjaxRequestErrorInfo { errorCode = errorCode, errorType = exceptionType, message = errorMsg };
            _iserror = true;
        }

        /// <summary>
        /// 执行结果
        /// </summary>
        /// <param name="context">控制器上下文</param>
        public override void ExecuteResult(ControllerContext context)
        {

            AjaxRequestResult obj = null;
            if (_obj is AjaxRequestResult)
            {
                obj = _obj as AjaxRequestResult;
            }
            else
            {
                obj = new AjaxRequestResult();
                if (!_iserror)
                {
                    obj.value = _obj;
                }
                else
                {
                    obj.error = _errorInfo;
                }
            }


            var req = context.HttpContext.Request;
            var resp = context.HttpContext.Response;
            var setting = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            var callback = req.QueryString["jsoncallback"];
            if (String.IsNullOrWhiteSpace(callback))
            {
                callback = req.QueryString["callback"];
            }

            if (String.IsNullOrWhiteSpace(callback))
            {
                resp.Write(JsonConvert.SerializeObject(obj, setting));
            }
            else //jsonp
            {

                resp.Write(callback);
                resp.Write("(");
                resp.Write(JsonConvert.SerializeObject(obj, setting));
                resp.Write(");");

            }

            base.ExecuteResult(context);


        }

    }
}