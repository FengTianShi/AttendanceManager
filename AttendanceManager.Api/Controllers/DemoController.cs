using System.Collections.Generic;
using System.Threading.Tasks;
using AttendanceManager.Api.Helper;
using AttendanceManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AttendanceManager.Api.Controllers
{
    [Route("Api/Demo")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IDemoManager demoManager;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public DemoController(IDemoManager demoManager)
        {
            this.demoManager = demoManager;
        }

        [HttpGet("QueryAllPersonInfoAsync")]
        public async Task<IList<PersonInfoModel>> QueryAllPersonInfoAsync()
        {
            return await demoManager.QueryAllPersonInfoAsync();
        }

        [HttpPost("QueryPersonInfoByIdAsync")]
        public async Task<PersonInfoModel> QueryPersonInfoByIdAsync([FromBody] int id)
        {
            return await demoManager.QueryPersonInfoByIdAsync(id);
        }

        [HttpPost("DeletePersonInfoByIdAsync")]
        public async Task<bool> DeletePersonInfoByIdAsync([FromBody] int id)
        {
            return await demoManager.DeletePersonInfoByIdAsync(id);
        }

        [HttpPost("UpdatePersonInfoByIdAsync")]
        public async Task<bool> UpdatePersonInfoByIdAsync([FromBody] PersonInfoModel person)
        {
            return await demoManager.UpdatePersonInfoByIdAsync(person);
        }

        [HttpPost("InsertPersonInfoAsync")]
        public async Task<bool> InsertPersonInfoAsync([FromBody] PersonInfoModel person)
        {
            return await demoManager.InsertPersonInfoAsync(person);
        }
    }
}

//Demo
//// GET api/values
//[HttpGet]
//public ActionResult<IEnumerable<string>> Get()
//{
//    return new string[] { "hello", "from server" };
//}

//// GET api/values/5
//[HttpGet("{id}")]
//public ActionResult<string> Get(int id)
//{
//    return "value";
//}

//// POST api/values
//[HttpPost]
//public void Post([FromBody] string value)
//{
//}

//// PUT api/values/5
//[HttpPut("{id}")]
//public void Put(int id, [FromBody] string value)
//{
//}

//// DELETE api/values/5
//[HttpDelete("{id}")]
//public void Delete(int id)
//{
//}