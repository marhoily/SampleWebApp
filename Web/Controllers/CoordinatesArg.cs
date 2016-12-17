using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Web.Controllers
{
    /// <summary>
    /// Argument
    /// </summary>
    public sealed class CoordinatesArg
    {
        /// <summary>
        /// Explanation for name property
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Longitude { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class NodeDto
    {
        /// <summary>
        /// Explanation for name property
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Longitude { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class GraphDto
    {
        /// <summary>
        /// 
        /// </summary>
        public List<NodeDto>   Nodes { get; set; }
    }
}