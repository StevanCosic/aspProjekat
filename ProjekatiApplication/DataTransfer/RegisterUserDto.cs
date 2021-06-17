using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication.DataTransfer
{
    public class RegisterUserDto
    {
        public int id { get; set; }
      
        public string email { get; set; }
       
        public string name { get; set; }
       
        public string Lname { get; set; }
      
        public string password { get; set; }

    }
}
