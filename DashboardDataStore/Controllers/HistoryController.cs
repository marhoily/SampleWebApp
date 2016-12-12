using System.Web.Http;
using DashboardDataStore.Data;
using DashboardDataStore.Queries;

namespace DashboardDataStore.Controllers
{
    public class HistoryController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var context = new Context())
                return Json(new History(context.Get()));
        }
    }
}
