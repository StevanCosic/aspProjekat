using Microsoft.AspNetCore.Mvc;
using PorjekatDataAccsess;
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
    
    public class Register : ControllerBase
    {

        public readonly UseCaseExecutor _executor;

        public Register(UseCaseExecutor executor)
        {
            _executor = executor;
        }





        // POST api/<Register>
        [HttpPost]
        public void Post([FromBody] RegisterUserDto dto , 
            [FromServices] IRegisterUserCommand command)
        {
            _executor.ExeCommand(command, dto);



        }

        
    }
}
