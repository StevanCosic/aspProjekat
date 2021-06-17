using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PorjekatDataAccsess;
using ProjekatiApplication.DataTransfer;

namespace ProjekatImplementation.validation
{
    public class messageValidate:AbstractValidator<messageDto>
    {
        public messageValidate(ProjekatDbContext context)
        {

            RuleFor(x => x.Message).NotEmpty().MaximumLength(100).WithMessage("Message is requierd");
          



        }

    }
}
