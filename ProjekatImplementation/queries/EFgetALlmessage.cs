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
    public class EFgetALlmessage : IGetAllMessages


    {
        private readonly ProjekatDbContext _context;

        public EFgetALlmessage(ProjekatDbContext context)
        {
            _context = context;
        }

        public int id => 5;

        public string name => "Show all messages";

        public PageResponse<messageDto> Execute(groupSearch search)
        {

            var query = _context.MessageForAdmin.AsQueryable();

          
            var skipCount = search.perPage * (search.page - 1);
            var response = new PageResponse<messageDto>
            {
                CurrentPage = search.page,
                ItemsPerPage = search.perPage,
                totalCount = query.Count(),
                items = query.Skip(skipCount).Take(search.perPage).Select(x => new messageDto
                {
                    id = x.id,
                    userId = x.userid,
                    Message = x.message
                    

                }).ToList()



            };
            return response;



        }
    }
}
