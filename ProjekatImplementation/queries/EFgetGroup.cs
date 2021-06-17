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
    public class EFgetGroup : IgetGroupQuery
    {

        private readonly ProjekatDbContext _context;

        public EFgetGroup(ProjekatDbContext context)
        {
            _context = context;
        }

        public int id => 4;

        public string name => "Group Search";

        public PageResponse<GroupeDto> Execute(groupSearch search)
        {
            var query = _context.group.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.name.ToLower() == search.Name.ToLower());


            }

            var skipCount = search.perPage * (search.page - 1);
            var response = new PageResponse<GroupeDto>
            {
                CurrentPage = search.page,
                ItemsPerPage = search.perPage,
                totalCount = query.Count(),
                items = query.Skip(skipCount).Take(search.perPage).Select(x => new GroupeDto
                {
                    id = x.id,
                    name = x.name
                }).ToList()

            };
            return response;



        }
    }
}
