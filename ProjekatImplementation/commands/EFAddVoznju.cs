using FluentValidation;
using PorjekatDataAccsess;
using ProjekatDomain;
using ProjekatiApplication;
using ProjekatiApplication.commands;
using ProjekatiApplication.DataTransfer;
using ProjekatImplementation.validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatImplementation.commands
{
    public class EFAddVoznju: IAddVoznju
    {
        private readonly ProjekatDbContext _context;
        private readonly driveValidator validator;
        private readonly IAplicationActor actor;

        public EFAddVoznju(ProjekatDbContext context, driveValidator validator, IAplicationActor actor)
        {
            _context = context;
            this.validator = validator;
            this.actor = actor;
        }

        public int id => 50;

        public string name => "Add Drive";

        public void Execute(voznjaDto request)
        {
            validator.ValidateAndThrow(request);

            var drive = new voznja
            {
               userId = actor.id,
               vozacId = request.vozacId,
               Tip_Autaid = request.tipKola,
               markaKolaid = request.markaKola,
               adresa = request.adresa


               


            };
            _context.voznja.Add(drive);
            _context.SaveChanges();




        }
    }
}
