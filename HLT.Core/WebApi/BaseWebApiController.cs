using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace HLT.Core.WebApi
{
    public class BaseWebApiController : ApiController
    {
        protected HttpResponseMessage JsonMsg<T>(T t, HttpStatusCode code)
        {
            return ResponseMessageResult.JsonMessage<T>(t, code);
        }
    }
}
