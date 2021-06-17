using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication
{
    public interface caseLogger
    {
        void Log(IUseCase userCase, IAplicationActor actor,object userCaseData);
    }
}
