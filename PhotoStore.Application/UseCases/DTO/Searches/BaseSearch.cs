﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.Application.UseCases.DTO.Searches
{
    public class BaseSearch
    {
        public string Keyword { get; set; }
    }

    public class PagedSearch
    {
        public int? PerPage { get; set; } = 15;
        public int? Page { get; set; } = 1;
    }

    public class BasePagedSearch : PagedSearch
    {
        public string Keyword { get; set; }
    }
}
