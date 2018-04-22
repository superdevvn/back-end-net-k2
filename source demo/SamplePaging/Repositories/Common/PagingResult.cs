using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Common
{
    public class PagingResult
    {
        public int Total { get; set; }

        public IEnumerable Entities { get; set; }
    }
}
