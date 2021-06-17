using System;
using System.Collections.Generic;
using System.Text;
using PorjekatDataAccsess;
using ProjekatiApplication.commands;
using ProjekatiApplication.exepction;
using ProjekatDomain;

namespace ProjekatImplementation.commands
{
    public class EFdeleteGroupCommand : iDeledeGroupeCommand
    {
        private readonly ProjekatDbContext _context;

        public EFdeleteGroupCommand(ProjekatDbContext context)
        {
            _context = context;
        }

        public int id => 3;

        public string name => "Delete Groupe";

        public void Execute(int request)
        {
            var group = _context.group.Find(request);
            
            if(group == null)
            {
                throw new EntityNotFound(request, typeof(group));
            }
            _context.group.Remove(group);
            _context.SaveChanges();
        }
    }
}
