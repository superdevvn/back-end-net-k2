using System.Collections;

namespace TravelManagement.Repositories
{
    public class PagingResult
    {
        public int Total { get; set; }

        public IEnumerable Entities { get; set; }
    }
}
