using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication.exepction
{
    public class WrongUser : Exception
    {
        public WrongUser(int id, Type type)

            : base($"entity of type {type.Name} with id {id} trying to delete or change something that is not his")
        {

        }



    }
}
