using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using PorjekatDataAccsess;
using ProjekatiApplication.DataTransfer;

namespace ProjekatImplementation.validation
{
    public class registrationValidator : AbstractValidator<RegisterUserDto>
    {

        public registrationValidator(ProjekatDbContext _context)
        {
            RuleFor(x => x.name).NotEmpty();
            RuleFor(x => x.Lname).NotEmpty();
            RuleFor(x => x.password).NotEmpty().MinimumLength(6);

            RuleFor(x => x.email).NotEmpty().MinimumLength(4).Must(x => !_context.user.Any(users => users.email == x)).WithMessage("Email Is alreay in Taken");




        }
    }
}
