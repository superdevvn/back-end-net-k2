using System;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
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

        [HttpPost]
        [Route("getTours")]
        public async Task<IHttpActionResult> GetTours()
        {
            return Ok(await tourService.GetList());
        }

        [HttpPost]
        [Route("getPagedTours")]
        public async Task<IHttpActionResult> GetPagedTours(JObject json)
        {
            var orderBy = json["orderBy"].ToString();
            var orderDirection = json["orderDirection"].ToString();
            var page = int.Parse(json["page"].ToString());
            var pageSize = int.Parse(json["pageSize"].ToString());
            var whereClause = json["whereClause"].ToString();
            return Ok(await tourService.GetList(orderBy, orderDirection, page, pageSize, whereClause));
        }
    }
}
