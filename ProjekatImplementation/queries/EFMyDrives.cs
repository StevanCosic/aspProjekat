using PorjekatDataAccsess;
using ProjekatiApplication;
using ProjekatiApplication.DataTransfer;
using ProjekatiApplication.queries;
using ProjekatiApplication.search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatImplementation.queries
{
    public class EFMyDrives : IMyDrives
    {

        private readonly ProjekatDbContext _context;
        private readonly IAplicationActor actor;

        public EFMyDrives(ProjekatDbContext context, IAplicationActor actor)
        {
            _context = context;
            this.actor = actor;
        }

        public int id => 55;

        public string name => "Show My Drives";

        public PageResponse<voznjaDto> Execute(groupSearch search)
        {
            var query = _context.voznja.AsQueryable();

            query = query.Where(x => x.userId == actor.id);
            var skipCount = search.perPage * (search.page - 1);
            var response = new PageResponse<voznjaDto>
            {
                CurrentPage = search.page,
                ItemsPerPage = search.perPage,
                totalCount = query.Count(),
                items = query.Skip(skipCount).Take(search.perPage).Select(x => new voznjaDto
                {
                    vozacId = x.vozacId,
                    markaKola = x.markaKolaid,
                    tipKola = x.Tip_Autaid,
                    adresa = x.adresa




                }).ToList()



            };
            return response;
        }
    }
}
