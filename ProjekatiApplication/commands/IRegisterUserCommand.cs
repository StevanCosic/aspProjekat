using ProjekatiApplication.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication.commands
{
    public interface IRegisterUserCommand : Command<RegisterUserDto>
    {
    }
}
