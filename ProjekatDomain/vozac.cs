﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatDomain
{
    public class vozac
    {
        public int id { get; set; }
        public string name { get; set; }
        public int years { get; set; }
        public int phone { get; set; }
        
        public virtual ICollection<voznja> voznja { get; set; }




    }
}
