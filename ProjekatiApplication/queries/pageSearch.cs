using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication.queries
{
    public abstract class pageSearch
    {

        public int perPage { get; set; } = 10;

        public int page { get; set; } = 1;
    }
}
