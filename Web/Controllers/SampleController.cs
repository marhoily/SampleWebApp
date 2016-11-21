using System.Collections.Generic;
using System.Web.Http;
using Serilog;

namespace Sample.Web.Controllers
{
    /// <summary>1 </summary>
    public class SampleController : ApiController
    {
        private readonly ILogger _log;

        /// <summary>2 </summary>
        public SampleController(ILogger log)
        {
            _log = log;
        }

        /// <summary>3 </summary>
        [Route("api/Sample")]
        public IEnumerable<object> Get()
        {
            _log.Information("api/Sample");
            return new object[] { 1, 2, 3};
        }
    }
}