using ProjekatiApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.core
{
    public class jwtActor : IAplicationActor
    {
        public int id  {get;set;}

        public string Indetity { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
