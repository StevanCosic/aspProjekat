using ProjekatiApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.core
{
    public class NonAccountUser : IAplicationActor
    {
        public int id => 0;

        public string Indetity => "Anonymus";

        public IEnumerable<int> AllowedUseCases => new List<int> { 4 };
    }
}
