using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication
{
    public interface IAplicationActor
    {
        int id { get; }
        string Indetity { get; }

        IEnumerable<int> AllowedUseCases { get; }



    }
}

  
