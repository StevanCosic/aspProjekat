using PorjekatDataAccsess;
using ProjekatiApplication.DataTransfer;
using ProjekatiApplication.queries;
using ProjekatiApplication.search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatImplementation.queries
{
    public class EfGetCommandQuery : IgetCommandsLogQuery
    {
        private readonly ProjekatDbContext _context;

        public EfGetCommandQuery(ProjekatDbContext context)
        {
            _context = context;
        }

        public int id => 15;

        public string name => "search command log";

        public PageResponse<commandCaseDto> Execute(groupSearch search)
        {
            var query = _context.useCaseLog.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.name.ToLower() == search.Name.ToLower());


            }
            var skipCount = search.perPage * (search.page - 1);
            var response = new PageResponse<commandCaseDto>
            {
                CurrentPage = search.page,
                ItemsPerPage = search.perPage,
                totalCount = query.Count(),
                items = query.Skip(skipCount).Take(search.perPage).Select(x => new commandCaseDto
                {
                    id = x.id,
                    name = x.name,
                    date = x.date,
                    data = x.Data
                    
                }).ToList()



            };
            return response;
        }
    }
}
