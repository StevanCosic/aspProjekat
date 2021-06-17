using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatDomain
{
    public class MessageForAdmin
    {
        public int id { get; set; }
        public string message { get; set; }
        public user user { get; set; }

        public int userid { get; set; }
    }
}
