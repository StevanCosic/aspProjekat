using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class uploadController : ControllerBase
    {
       

      

        // POST api/<uploadController>
        [HttpPost]
        public void Post([FromForm]UploadDto dto)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.image.CopyTo(fileStream);
            }

            //newfilename slanje u bazu


        }

        public class UploadDto
        {
            public IFormFile image { get; set; }
        }
      

     
    }
}
