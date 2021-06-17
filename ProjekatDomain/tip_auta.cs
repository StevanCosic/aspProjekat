using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatDomain
{
    public class tip_auta
    {
        public int id { get; set; }
        public string name { get; set; }
        public int sedista { get; set; }

        public virtual ICollection<voznja> voznja { get; set; }

    }
}
