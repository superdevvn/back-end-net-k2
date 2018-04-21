﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace SuperDev.Repositories
{
    public class PagedListResult
    {
        public int Total { get; set; }
        public IEnumerable Entities { get; set; }

        public PagedListResult(IEnumerable entities, int total)
        {
            Entities = entities;
            Total = total;
        }
    }
}
