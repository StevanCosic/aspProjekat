﻿using ProjekatiApplication.DataTransfer;
using ProjekatiApplication.search;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatiApplication.queries
{
    public interface IMyDrives : Iquery<groupSearch, PageResponse<voznjaDto>>
    {
    }
}
