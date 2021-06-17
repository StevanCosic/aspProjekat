using ProjekatiApplication.exepction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace ProjekatiApplication
{
    public class UseCaseExecutor
    {
        private readonly IAplicationActor actor;
        private readonly caseLogger logger;


        public UseCaseExecutor(IAplicationActor actor, caseLogger logger)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public Tresult executeQuery<Tsearch, Tresult>(Iquery<Tsearch,Tresult> query, Tsearch search)
        {
            
            logger.Log(query, actor, search);

           if (!actor.AllowedUseCases.Contains(query.id))
            {
               
                Console.WriteLine(actor.Indetity + " " +"can't execute query");
                throw new UnUseCaseExepction(query, actor);




            }
            return query.Execute(search);



        }



    




        public void ExeCommand<Trequest>(
            Command<Trequest> command, 
            Trequest request)
        {
            logger.Log(command, actor, request);

            if (!actor.AllowedUseCases.Contains(command.id))
            {
                Console.WriteLine(actor.Indetity + " " + "can't execute command");
                throw new UnUseCaseExepction(command, actor);
               



            }



            command.Execute(request);

           
        }


    }
}
