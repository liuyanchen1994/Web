using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace HTL.Core.WebApi
{
    public class BaseWebApiController : ApiController
    {
        protected HttpResponseMessage JsonMsg<T>(T t, HttpStatusCode code)
        {
            return ResponseMessageResult.JsonMessage<T>(t, code);
        }
    }
}
