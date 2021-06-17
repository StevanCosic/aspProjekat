using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication.queries
{
    public class PageResponse<T> where T : class 
    {

        public int totalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }

        public  IEnumerable<T> items { get; set; }

        public int PagesCount => (int)Math.Ceiling((float)totalCount / ItemsPerPage); 


    }
}
