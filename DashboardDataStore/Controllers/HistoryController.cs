using System.Web.Http;
using BuildStatisticsServices.Data;

namespace BuildStatisticsServices.Controllers
{
    using Queries;

    public class HistoryController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var context = new Context())
                return Json(new History(context.Get()));
        }
    }
}
