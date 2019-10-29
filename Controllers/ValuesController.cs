// using System.Resources;
// using System.Collections.Specialized;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using NLog;
// //using NLog.Web.AspNetCore; 
// //using NLog.Extensions.Logging;


// namespace WEBAPI.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ValuesController : ControllerBase
//     {
//         // GET api/values
//         [HttpGet]
//         //查询
//         // public ActionResult<IEnumerable<string>> Get()
//         // {
//         //     return new string[] { "value1", "value2" };
//         // }

//         // GET api/values/5
//         [HttpGet("{id}")]
//         public ActionResult<string> Get(int id)
//         {
//             return "value";
//         }

//         // POST api/values
//         //添加
//         [HttpPost]
//         public void Post([FromBody] string value)
//         {
//             //return value;
//         }

//         // PUT api/values/5
//         //修改
//         [HttpPut("{id}")]
//         public void Put(int id, [FromBody] string value)
//         {
//         }

//         // DELETE api/values/5
//         [HttpDelete("{id}")]
//         public void Delete(int id)
//         {
//         }
//         public Logger _logger;
//     }
// }
