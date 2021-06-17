using PorjekatDataAccsess;
using ProjekatDomain;
using ProjekatiApplication.commands;
using ProjekatiApplication.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatImplementation.commands
{
    public class EFAddCarType : IAddTypeCar
    {
        private readonly ProjekatDbContext _context;

        public EFAddCarType(ProjekatDbContext context)
        {
            _context = context;
        }

        public int id => 10;

        public string name => "Add Car Type";

        public void Execute(TypeDto request)
        {

            var newCarMark = new tip_auta
            {
                name = request.name,
                sedista = request.sedista
                
            };
            _context.tip_auto.Add(newCarMark);
            _context.SaveChanges();
        }
    }
}
