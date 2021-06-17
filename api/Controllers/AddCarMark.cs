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
    public class AddCarMark : ControllerBase
    {


        private readonly UseCaseExecutor executor;

        public AddCarMark(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<AddCarMark>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AddCarMark>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddCarMark>
        [HttpPost]
        public void Post([FromBody] MarkDto dto, [FromServices] ICreateNewCarMark comman)
        {
            executor.ExeCommand(comman, dto);



        }

        // PUT api/<AddCarMark>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddCarMark>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
