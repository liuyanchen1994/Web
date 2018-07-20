using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HLT.Domain;

namespace HLT.Web.Controllers
{
    public class TestController : ApiController
    {
        private readonly ITest _test;

        public TestController() { }
        public TestController(ITest test)
        {
            _test = test;
        }

        [HttpGet]
        public string Test(string id)
        {
            return _test.Add(id);
        }
    }
}
