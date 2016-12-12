using System;

namespace BuildStatisticsServices.Models
{
    [Serializable]
    public class CodeIssueType
    {
        public string Id { get; set; }

        public string Category { get; set; }
    }
}