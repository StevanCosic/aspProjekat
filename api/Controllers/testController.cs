using Microsoft.AspNetCore.Mvc;
using ProjekatiApplication.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjekatiApplication.commands;
using ProjekatiApplication;
using ProjekatiApplication.search;
using ProjekatiApplication.queries;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly UseCaseExecutor executor;


        private readonly IAplicationActor actor;


        public testController(IAplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }



        // GET: api/<testController>
        [HttpGet]
       


        public IActionResult Get([FromQuery] groupSearch search, [FromServices] IgetGroupQuery query)
        {
            return Ok(executor.executeQuery(query, search));
        }

        // GET api/<testController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<testController>
        [HttpPost]
        public void Post([FromBody] GroupeDto dto , [FromServices] IcreateGroupeCommand command)

        {
            executor.ExeCommand(command, dto);


        }

        // PUT api/<testController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<testController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices]iDeledeGroupeCommand command)
        {

            executor.ExeCommand(command, id);
            return NoContent();


        }
    }
}
