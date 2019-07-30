using System.Collections.Generic;
using System.Threading.Tasks;
using AttendanceManager.Api.Helper;
using AttendanceManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace AttendanceManager.Api.Controllers
{
    [Route("api/demo")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IDemoManager demoManager;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public DemoController(IDemoManager demoManager)
        {
            this.demoManager = demoManager;
        }

        [HttpPost("queryPersonInfoAsync")]
        public ActionResult<bool> QueryPersonInfoAsync()
        {
            logger.Trace("Trace Message");
            logger.Debug("Debug Message");
            logger.Info("Info Message");
            logger.Error("Error Message");
            logger.Fatal("Fatal Message");
            return false;
        }

        [HttpGet("testQueryAllPersonInfoAsync")]
        public async Task<IList<PersonInfoModel>> QueryAllPersonInfoAsync()
        {
            return await demoManager.QueryAllPersonInfoAsync();
        }

        [HttpGet("testQueryPersonInfoByIdAsync")]
        public async Task<PersonInfoModel> QueryPersonInfoByIdAsync()
        {
            return await demoManager.QueryPersonInfoByIdAsync(1);
        }

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
    }
}
