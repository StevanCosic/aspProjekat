using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication
{
    public interface Command<Trequest>:IUseCase
    {
        void Execute(Trequest request);
    }

     public interface Iquery<Tsearch,Tresult>:IUseCase
    {


       Tresult Execute(Tsearch search);

    }   

    public interface IUseCase
    {
        int id { get; }
        string name { get; }

        
    }

 

  
}
