using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatDomain
{
    public class markaKola
    {
        public int id { get; set; }
        public string name { get; set; }
        
        public string image { get; set; }

        public virtual ICollection<voznja> voznja { get; set; }

    }
}
