using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using PorjekatDataAccsess;
using ProjekatiApplication.DataTransfer;

namespace ProjekatImplementation.validation
{
    public class driveValidator : AbstractValidator<voznjaDto>
    {
        public driveValidator(ProjekatDbContext context)
        {
            RuleFor(x => x.adresa).NotEmpty().MaximumLength(50).WithMessage("please enter your adress");
          

            RuleFor(x => x.vozacId).NotEmpty()
               .Must(vozac => context.vozac.Any(y => y.id == vozac))
               .WithMessage("Driver does not exist");

            RuleFor(x => x.tipKola).NotEmpty()
               .Must(autoTip => context.tip_auto.Any(y => y.id == autoTip))
               .WithMessage("Type Of Car Does Not Exist");

            RuleFor(x => x.markaKola).NotEmpty()
             .Must(autoMark => context.markaKola.Any(y => y.id == autoMark))
             .WithMessage("Mark Of Car Does Not Exist");
        }

    }
}
