using System.ComponentModel.DataAnnotations;

namespace Sample.Web.Controllers
{
    /// <summary>
    /// Argument
    /// </summary>
    public sealed class SampleArg
    {
        /// <summary>
        /// Explanation for name property
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}