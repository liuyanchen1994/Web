using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;

namespace HTL.Core.Serialize
{
    /// <summary>
    /// Xml序列化与反序列化
    /// </summary>
    public class Xml
    {
        /// <summary>
        /// 缓存转换程序集，提高效率，防止内存溢出
        /// </summary>
        private static Hashtable _hash = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlStr)
        {
            if (string.IsNullOrEmpty(xmlStr)) return default(T);
            string key = GenerateKey(typeof(T));
            StringReader sr = null;
            XmlSerializer ser = (XmlSerializer)_hash[key];
            if (ser == null)
            {
                ser = new XmlSerializer(typeof(T));
                _hash[key] = ser;
            }
            try
            {
                sr = new StringReader(xmlStr);
                return (T)ser.Deserialize(sr);
            }
            catch
            {
                return default(T);
            }
            finally
            {
                if (sr != null) sr.Dispose();
            }
        }
        /// <summary>
        /// XML序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string Serialize<T>(T entity)
        {
            MemoryStream ms = null;
            StreamReader sr = null;
            string str = string.Empty;
            string key = GenerateKey(typeof(T));
            XmlSerializer ser = (XmlSerializer)_hash[key];
            if (ser == null)
            {
                ser = new XmlSerializer(typeof(T));
                _hash[key] = ser;
            }
            try
            {
                ms = new MemoryStream();
                ser.Serialize(ms, entity);
                ms.Position = 0;
                sr = new StreamReader(ms);
                str = sr.ReadToEnd();
            }
            finally
            {
                if (sr != null) sr.Dispose();
                if (ms != null) ms.Dispose();
            }
            return str;
        }
        /// <summary>
        /// 缓存类型创建Key
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        private static string GenerateKey(Type tp)
        {
            return tp.FullName.GetHashCode().ToString();
        }
    }
}
