using System.Web;
using System.Web.Mvc;

namespace HLT.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //系统级错误处理日志记录
            filters.Add(new Filters.ErrorException());
        }
    }
}
