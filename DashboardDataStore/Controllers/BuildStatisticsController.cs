using System.Linq;
using System.Web.Http;
using DashboardDataStore.Data;
using DashboardDataStore.Models;

namespace DashboardDataStore.Controllers
{
    public class BuildStatisticsController : ApiController
    {
        public IHttpActionResult Post([FromBody] BuildStatistics statistics)
        {
            using (var context = new Context())
            {
                context.Add(statistics);
                context.SaveChanges();
            }

            return Ok();
        }
        public IHttpActionResult Get()
        {
            using (var context = new Context())
            return Json(context.Get().ToArray());
        }
    }
}
