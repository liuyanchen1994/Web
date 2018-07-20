using System;
using log4net;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using HLT.Core.WebApi;

namespace HLT.Web.Filters
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        public static ILog SysLogger = log4net.LogManager.GetLogger("ApiLogger");
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string ErrorMsg = string.Format("地址：{0} Controller：{1} Action：{2} 错误日志：{3}",
                actionExecutedContext.Request.RequestUri.AbsoluteUri,
                actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                actionExecutedContext.Exception.Message
                );
            SysLogger.Error(ErrorMsg);
            actionExecutedContext.Response = ResponseMessageResult.JsonMessage(new { ret = true, msg = "接口错误" }, HttpStatusCode.OK);
        }
    }
}