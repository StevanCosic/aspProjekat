using Microsoft.AspNetCore.Mvc;
using ProjekatiApplication;
using ProjekatiApplication.queries;
using ProjekatiApplication.search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMessagesShow : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public AdminMessagesShow(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<AdminMessagesShow>
        [HttpGet]
        public IActionResult Get([FromQuery] groupSearch search, [FromServices] IGetAllMessages query)
        {
            return Ok(executor.executeQuery(query, search));
        }

        // GET api/<AdminMessagesShow>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminMessagesShow>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminMessagesShow>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminMessagesShow>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
