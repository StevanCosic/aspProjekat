using ProjekatiApplication;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProjekatImplementation.logger
{
    public class consoleLogger : caseLogger
    {
        public void Log(IUseCase userCase, IAplicationActor actor, object userCaseData)
        { 
            Console.WriteLine(actor.Indetity + " " + "is trying to execute command" + userCase.name + " " + JsonConvert.SerializeObject(userCase));
        }
    }
}
