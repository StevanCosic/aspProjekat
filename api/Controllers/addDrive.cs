using Microsoft.AspNetCore.Mvc;
using ProjekatiApplication;
using ProjekatiApplication.commands;
using ProjekatiApplication.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class addDrive : ControllerBase
    {

        private readonly UseCaseExecutor executor;

        public addDrive(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<addDrive>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<addDrive>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<addDrive>
        [HttpPost]
        public void Post([FromBody] voznjaDto dto, [FromServices] IAddVoznju command)

        {
            executor.ExeCommand(command, dto);


        }

        // PUT api/<addDrive>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<addDrive>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
