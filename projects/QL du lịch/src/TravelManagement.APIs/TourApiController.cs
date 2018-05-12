using System.Threading.Tasks;
using System.Web.Http;
using TravelManagement.Models;
using TravelManagement.Services;

namespace TravelManagement.APIs
{
    [RoutePrefix("api")]
    public class TourApiController:ApiController
    {
        TourService tourService = new TourService();
        [HttpPost]
        [Route("createTour")]
        public async Task<IHttpActionResult> Create(Tour tour)
        {
            return Ok(await tourService.Create(tour));
        }
    }
}
