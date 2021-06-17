using ProjekatiApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.core
{
    public class FakeApikorisnik : IAplicationActor
    {
        public int id => 1;
        public string Indetity => "Test Api USER";

        public IEnumerable<int> AllowedUseCases => new List<int> {1};



    }
    public class adminActorFake : IAplicationActor
    {
        public int id => 2;

        public string Indetity => "FakeAdmin";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 1000);
    }
}
