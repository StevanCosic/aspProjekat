using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using PorjekatDataAccsess;
using ProjekatiApplication.DataTransfer;

namespace ProjekatImplementation.validation
{
    public class createGroupValidator:AbstractValidator<GroupeDto>
    {
        public createGroupValidator(ProjekatDbContext context)
        {
            RuleFor(x => x.name).NotEmpty()
                .Must(name => !context.group.Any(y => y.name == name)).WithMessage("name must be unique");
                

        }
    }
}
