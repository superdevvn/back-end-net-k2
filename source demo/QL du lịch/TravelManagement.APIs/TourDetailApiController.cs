using System.Threading.Tasks;
using System.Web.Http;
using TravelManagement.Models;
using TravelManagement.Services;

namespace TravelManagement.APIs
{
    [RoutePrefix("api")]
    public class TourDetailApiController:ApiController
    {
        TourDetailService tourDetailService = new TourDetailService();
        [HttpPost]
        [Route("createTourDetail")]
        public async Task<IHttpActionResult> Create(TourDetail tourDetail)
        {
            return Ok(await tourDetailService.Create(tourDetail));
        }

        [HttpPost]
        [Route("updateTourDetail")]
        public async Task<IHttpActionResult> Update(TourDetail tourDetail)
        {
            return Ok(await tourDetailService.Update(tourDetail));
        }
    }
}
