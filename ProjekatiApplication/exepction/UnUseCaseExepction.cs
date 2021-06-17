using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication.exepction
{
    public class UnUseCaseExepction :Exception
    {

        public UnUseCaseExepction(IUseCase useCase, IAplicationActor actor)
          :base($"Actor with {actor.id} - {actor.Indetity} tried to {useCase.id} {useCase.name} not allowed")
        {
            


        }


    }
}
