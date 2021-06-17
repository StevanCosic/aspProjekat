using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatDomain
{
    public class user
    {
        public int id { get; set; }
        [Required]
        public string email { get; set; }
        [Required]

       
        public string name { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        public string password { get; set; }

        public virtual ICollection<userUseCase> userUseCase { get; set; }
        public virtual ICollection<MessageForAdmin> MessageForAdmin { get; set; }


    }
}
