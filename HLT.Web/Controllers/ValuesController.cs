using System;
using System.Collections.Generic;
using System.Web.Http;

namespace HLT.Web.Controllers
{
    
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST api/values
        public string Post([FromBody]string value)
        {
            return value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        
        [HttpPost]
        public IHttpActionResult Add(Student student)
        {
            string a = "qwe";
            int i = int.Parse(a);
            return Json(student);
        }

    }

    /// <summary>
    /// 学生实体
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        public string[] Sum { get; set; }

    }
}
