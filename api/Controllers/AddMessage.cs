using Microsoft.AspNetCore.Mvc;
using ProjekatiApplication;
using ProjekatiApplication.commands;
using ProjekatiApplication.DataTransfer;
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
    public class AddMessage : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public AddMessage(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<AddMessage>
        [HttpGet]
        public IActionResult Get([FromQuery] groupSearch search, [FromServices] IshowMyMessage query)
        {
            return Ok(executor.executeQuery(query, search));
        }

        // GET api/<AddMessage>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddMessage>
        [HttpPost]
        public void Post([FromBody] messageDto dto, [FromServices] IaddMessage comman)
        {
            executor.ExeCommand(comman, dto);



        }

        // PUT api/<AddMessage>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddMessage>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IdeleteMessage command)
        {

            executor.ExeCommand(command, id);
            return NoContent();


        }
    }
}
