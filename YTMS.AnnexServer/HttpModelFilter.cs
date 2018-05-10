using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

using YTMS.Common.Core;
namespace YTMS.AnnexServer
{
    public class HttpModelFilter : IHttpModule
    {
        readonly string singKey = ConfigurationManager.AppSettings.Get("AnnexServerSignKey");
        public void Dispose()
        {
           
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += Context_PreRequestHandlerExecute;
        }

        private void Context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var req = app.Request;

            var ext = GetExtend(req.Url.ToString());

            if (!IgnoreList.Contains(ext))
            {
                var sign = req["sign"];
                var rdn = req["rdn"];

                if (string.IsNullOrWhiteSpace(sign) || string.IsNullOrWhiteSpace(rdn))
                {
                    WriteBadResponse(app.Response);
                }
                else
                {
                    var curRdn =(HelpSup.Get10BitTimeStamp2(DateTime.Now));
                    long _rdn = 0;
                    if (long.TryParse(rdn, out _rdn))
                    {
                        if ((curRdn - _rdn) > (1 * 60 * 1000))//超过1分钟表示sign签名失效
                            WriteBadResponse(app.Response);

                        var sign2 = HelpSup.Get32bitMd5(singKey + rdn);
                        if (sign2 != sign.ToUpper())
                            WriteBadResponse(app.Response);
                    }
                    else
                    {
                        WriteBadResponse(app.Response);
                    }
                  
                }

            }
        }

        private void WriteBadResponse(HttpResponse response)
        {
            response.ContentType = "application/json";
            response.ClearContent();
            response.Write("{\"errorcode\":\"400\",\"message\":\"Bad Request\"}");
            response.StatusCode = 400;
            response.End();
        }

        private List<string> IgnoreList = new List<string>()
        {
             "png",
             "jpg",
             "jpeg",
             "bmp",
             "json"
        };

        private string GetExtend(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return string.Empty;

            var ext = string.Empty;

            if (url.IndexOf('?') != -1)
                url = url.Split('?')[0];

            var pos = url.LastIndexOf('.');
            if (pos != -1)
                ext = url.Substring(pos + 1).ToLower();
            return ext;
        }
    }
}