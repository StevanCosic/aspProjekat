using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PorjekatDataAccsess;
using ProjekatiApplication.DataTransfer;

namespace ProjekatImplementation.validation
{
    public class driverValidation:AbstractValidator<driverDto>
    {
        public driverValidation(ProjekatDbContext context)
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Name is requierd");

            RuleFor(x => x.phone).NotEmpty().LessThan(999999999).WithMessage("Number format is 999-999-999");
            RuleFor(x => x.years).NotEmpty().LessThan(50).WithMessage("Max years are 50");




        }

    }
}
