using Newtonsoft.Json;
using PorjekatDataAccsess;
using ProjekatDomain;
using ProjekatiApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatImplementation.logger
{
    public class DataBaseUseCaseLogger : caseLogger
    {
        private readonly ProjekatDbContext _context;
        public DataBaseUseCaseLogger(ProjekatDbContext context)
        {
            _context = context;
        }

        public void Log(IUseCase userCase, IAplicationActor actor, object userCaseData)
        {
            var usLog = new useCaseLog
            {

                actor = actor.Indetity,
                Data = JsonConvert.SerializeObject(userCaseData),
                date = DateTime.UtcNow,
                name = userCase.name
                








            };
            _context.useCaseLog.Add(usLog);
            _context.SaveChanges();


        }
    }
}
