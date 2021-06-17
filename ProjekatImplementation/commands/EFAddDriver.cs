using FluentValidation;
using PorjekatDataAccsess;
using ProjekatDomain;
using ProjekatiApplication.commands;
using ProjekatiApplication.DataTransfer;
using ProjekatImplementation.validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatImplementation.commands
{
    public class EFAddDriver : IAddDriver
    {
        private readonly ProjekatDbContext _context;
        private readonly driverValidation validator;

        public EFAddDriver(ProjekatDbContext context, driverValidation validator)
        {
            _context = context;
            this.validator = validator;
        }

        public int id => 11;

        public string name => "Add Driver";

        public void Execute(driverDto request)
        {
            validator.ValidateAndThrow(request);
            var driver = new vozac
            {
                name = request.name,
                years = request.years,
                phone = request.phone

            };
            _context.vozac.Add(driver);
            _context.SaveChanges();
        }
    }
}
