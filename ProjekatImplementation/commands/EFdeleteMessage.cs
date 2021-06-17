using System;
using System.Collections.Generic;
using System.Text;
using PorjekatDataAccsess;
using ProjekatiApplication.commands;
using ProjekatiApplication.exepction;
using ProjekatDomain;
using ProjekatiApplication;

namespace ProjekatImplementation.commands
{
    public class EFdeleteMessage : IdeleteMessage

    {
        private readonly ProjekatDbContext _context;
        private readonly IAplicationActor actor;

        public EFdeleteMessage(ProjekatDbContext context, IAplicationActor actor)
        {
            _context = context;
            this.actor = actor;
        }

        public int id => 22;

        public string name => "Delete you message for Admin";

        public void Execute(int request)
        {
            var message = _context.MessageForAdmin.Find(request);
            if(message == null)
            {
                throw new EntityNotFound(request, typeof(MessageForAdmin));
            }
            if (message.userid != actor.id)
            {
                throw new WrongUser(request, typeof(MessageForAdmin));
            }
            _context.MessageForAdmin.Remove(message);
            _context.SaveChanges();

        }
    }
}
