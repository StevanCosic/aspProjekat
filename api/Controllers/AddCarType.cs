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
    public class AddCarType : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public AddCarType(UseCaseExecutor executor)
        {
            this.executor = executor;
        }




        // POST api/<AddCarType>
        [HttpPost]
        public void Post([FromBody] TypeDto dto, [FromServices] IAddTypeCar comman)
        {
            executor.ExeCommand(comman, dto);



        }


    }
}
