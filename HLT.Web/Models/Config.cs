using log4net;

namespace HLT.Web.Models
{
    public class Config
    {
        static Config()
        {
            Init();
        }
        /// <summary>
        /// 调用配置文件进行初始化系统
        /// </summary>
        internal static void Init()
        {
            //初始化Logger
            SysLog = LogManager.GetLogger("SysLogger");
            ApiLog = LogManager.GetLogger("ApiLogger");
        }

        public const string CookieKey = "$_Token$";

        #region Logger
        public static ILog SysLog;
        public static ILog ApiLog;
        #endregion
    }
}