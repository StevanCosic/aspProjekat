using PorjekatDataAccsess;
using ProjekatDomain;
using ProjekatiApplication.commands;
using ProjekatiApplication.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatImplementation.commands
{
    public class EFNewCarMark : ICreateNewCarMark
    {

        private readonly ProjekatDbContext _context;

        public EFNewCarMark(ProjekatDbContext context)
        {
            _context = context;
        }

        public int id => 9;

        public string name => "New Car Mark";

        public void Execute(MarkDto request)
        {



            var newCarMark = new markaKola
            {
                name = request.name
            };
            _context.markaKola.Add(newCarMark);
            _context.SaveChanges();
        }
    }
}
