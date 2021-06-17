using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatDomain
{
    public class userUseCase
    {
        public int id { get; set; }
        public int UserID { get; set; }
        public int UseCaseId { get; set; }

        public virtual user user { get; set; }

    }
}
