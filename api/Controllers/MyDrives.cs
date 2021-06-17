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
    public class MyDrives : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public MyDrives(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<MyDrives>
        [HttpGet]
        public IActionResult Get([FromQuery] groupSearch search, [FromServices] IMyDrives query)
        {
            return Ok(executor.executeQuery(query, search));
        }

        // GET api/<MyDrives>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MyDrives>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MyDrives>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MyDrives>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
