using System.Net.Http;
using System.IO;
using System.Net;

namespace HLT.Core.WebApi
{
    public class ResponseMessageResult
    {
        /// <summary>
        /// 定义JSON序列化的byte[]返回流
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static HttpResponseMessage JsonMessage<T>(T t, HttpStatusCode code = HttpStatusCode.OK)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(t);// Geo.Helper.Serialize.Json.Serialize<T>(t);
            
            return new HttpResponseMessage(code)
            {
                Content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(json))
            };
        }
    }
}
