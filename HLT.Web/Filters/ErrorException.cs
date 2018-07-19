using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HLT.Web.Filters
{
    /// <summary>
    /// 自定义全局错误处理
    /// </summary>
    public class ErrorException :  IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string ErrorMsg = string.Format("地址：{0} Controller：{1} Action：{2} 错误日志：{3}",
                filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri,
                filterContext.RouteData.Values["controller"],
                filterContext.RouteData.Values["action"],
                filterContext.Exception.Message
                );
            Models.Config.SysLog.Error(ErrorMsg);
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    ContentType = "text/plain",
                    Data = new { ret = false, msg = "系统出现异常，访问出错！" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            filterContext.Result = new ContentResult
            {
                Content = "系统出现异常，异常原因：" + filterContext.Exception.Message
            };
            filterContext.ExceptionHandled = true;
        }
    }
}