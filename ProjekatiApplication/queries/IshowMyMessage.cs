using ProjekatiApplication.DataTransfer;
using ProjekatiApplication.search;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication.queries
{
    public interface IshowMyMessage : Iquery<groupSearch, PageResponse<messageDto>>
    {
    }
}
