using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Models;
using TravelManagement.Models.Common;

namespace TravelManagement.Repositories
{
    public class TourRepository : BaseRepository<Tour>
    {
        public override async Task<Tour> Get(Guid id)
        {
            using (var context = new TMDbContext())
            {
                var tour = await context.Tours.Where(e => e.Id == id)
                    .Include(e => e.TourDetails)
                    .FirstOrDefaultAsync();
                tour.TourDetails.ForEach(e => e.Tour = null);
                return tour;
            }
        }
    }
}
