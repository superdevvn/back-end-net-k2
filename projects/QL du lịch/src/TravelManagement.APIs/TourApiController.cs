using System;
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

        [HttpPost]
        [Route("updateTour")]
        public async Task<IHttpActionResult> Update(Tour tour)
        {
            return Ok(await tourService.Update(tour));
        }

        [HttpGet]
        [Route("getTour")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            return Ok(await tourService.Get(id));
        }
    }
}
