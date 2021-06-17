using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication.exepction
{
    public class EntityNotFound : Exception 
    {
        public EntityNotFound(int id, Type type)
        
            :base($"entity of type {type.Name} with id {id} not found")
        {

        }

        

    }
}
