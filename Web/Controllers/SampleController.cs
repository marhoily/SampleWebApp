using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Logic.Database;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Sample.Web.Controllers
{
    /// <summary>1 </summary>
    public class SampleController : ApiController
    {
        private readonly DbContextOptions<GraphContext> _options;
        private readonly ILogger _log;

        /// <summary>2 </summary>
        public SampleController(DbContextOptions<GraphContext> options, ILogger log)
        {
            _options = options;
            _log = log;

        }

        /// <summary>13 </summary>
        [Route("api/graph/node")]
        public async void Post([FromBody] CoordinatesArg arg)
        {
            _log.Information("create node {coordinates}", arg);
            using (var ctx = new GraphContext(_options))
            {
                ctx.Add(new Node { Latitude = arg.Latitude, Longitude = arg.Longitude });
                await ctx.SaveChangesAsync();
            }
        }

        /// <summary>3 </summary>
        [Route("api/graph")]
        public async Task<object> Get()
        {
            using (var ctx = new GraphContext(_options))
            {
                var nodes = await ctx.Nodes.ToListAsync();
                var graphDto = new
                {
                    Nodes = nodes.Select(n => new
                        {
                            Coordinates = new
                            {
                                n.Latitude,
                                n.Longitude
                            }
                        }
                    )
                };
                return graphDto;
            }
        }


        private List<NodeDto> Map(List<Node> nodes)
        {
            return nodes.Select(Map).ToList();
        }

        private NodeDto Map(Node arg)
        {
            return new NodeDto
            {
                Latitude = arg.Latitude,
                Longitude = arg.Longitude
            };
        }
    }
}