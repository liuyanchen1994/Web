using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLT.Web.Models
{
    /// <summary>
    /// 配置的基类，包含保存，加载配置文件的序列化方法
    /// </summary>
    public class BaseConfig
    {
        private const string SavePath = "~/Config/";
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        protected static T Load<T>() where T : class, new()
        {
            string fileName = typeof(T).FullName + ".config";
            string _path = System.Web.HttpContext.Current.Server.MapPath(SavePath + fileName);
            string xml = HLT.Core.Helper.FileHelper.ReadFile(_path);
            var config = HLT.Core.Serialize.Xml.Deserialize<T>(xml);
            return config != null ? config : new T();
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="t"></param>
        protected static void Save<T>(T t) where T : class, new()
        {
            string fileName = typeof(T).FullName + ".config";
            string _path = System.Web.HttpContext.Current.Server.MapPath(SavePath + fileName);
            string xml = HLT.Core.Serialize.Xml.Serialize<T>(t);
            HLT.Core.Helper.FileHelper.CreateFile(_path, xml);
        }
    }
}