using PorjekatDataAccsess;
using ProjekatiApplication.commands;
using ProjekatiApplication.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using ProjekatDomain;
using ProjekatImplementation.validation;
using FluentValidation;

namespace ProjekatImplementation.commands
{

   
    public class EfCreateGroupeCommand : IcreateGroupeCommand
    {

        private readonly ProjekatDbContext _context;
        private readonly createGroupValidator validator;

        public EfCreateGroupeCommand(ProjekatDbContext context, createGroupValidator validator)
        {
            _context = context;
            this.validator = validator;
        }

        public int id => 1;

        public string name => "Create New Group Using EF";

        public void Execute(GroupeDto request)
        {

            validator.ValidateAndThrow(request);


            var group = new group
            {
                name = request.name
            };
            _context.group.Add(group);
            _context.SaveChanges();
        }
    }
}
