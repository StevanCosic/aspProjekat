using PorjekatDataAccsess;
using ProjekatDomain;
using ProjekatiApplication;
using ProjekatiApplication.commands;
using ProjekatiApplication.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatImplementation.commands
{
    public class EFmessage : IaddMessage
    {
        private readonly ProjekatDbContext _context;
        private readonly IAplicationActor actor;

        public EFmessage(ProjekatDbContext context, IAplicationActor actor)
        {
            _context = context;
            this.actor = actor;
        }

        public int id => 20;

        public string name => "add message";

        public void Execute(messageDto request)
        {
            var message = new MessageForAdmin
            {

                message = request.Message,
                userid = actor.id





            };
            _context.MessageForAdmin.Add(message);
            _context.SaveChanges();
        }
    }
}
