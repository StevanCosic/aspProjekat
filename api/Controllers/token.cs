using api.core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class token : ControllerBase
    {

        private readonly jwtManager manager;

        public token(jwtManager manager)
        {
            this.manager = manager;
        }

        // POST api/<token>
        [HttpPost]
        public ActionResult Post([FromBody] loginRequest request)
        {
            var token = manager.MakeToken(request.email, request.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new
            {
                token 

            });

        }

        public class loginRequest
        {
            public string email { get; set; }
            public string password { get; set; }


        }

      
    }
}
