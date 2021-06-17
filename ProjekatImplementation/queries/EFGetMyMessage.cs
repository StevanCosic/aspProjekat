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
    public class EFGetMyMessage : IshowMyMessage 
    {
        private readonly ProjekatDbContext _context;
        private readonly IAplicationActor actor;

        public EFGetMyMessage(ProjekatDbContext context, IAplicationActor actor)
        {
            _context = context;
            this.actor = actor;
        }

        public int id => 30;

        public string name => "Search my messages";

        public PageResponse<messageDto> Execute(groupSearch search)
        {

            var query = _context.MessageForAdmin.AsQueryable();

            query = query.Where(x => x.userid == actor.id);
            var skipCount = search.perPage * (search.page - 1);
            var response = new PageResponse<messageDto>
            {
                CurrentPage = search.page,
                ItemsPerPage = search.perPage,
                totalCount = query.Count(),
                items = query.Skip(skipCount).Take(search.perPage).Select(x => new messageDto
                {
                    Message = x.message,
                    userId = x.userid,
                    id = x.id



                }).ToList()



            };
            return response;

        }
    }
}
