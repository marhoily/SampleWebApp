using System;
using System.Collections.Generic;

namespace BuildStatisticsServices.Models
{
    [Serializable]
    public class CodeInspection : List<CodeIssueType>
    {
        public ICollection<CodeIssueType> IssueTypes { get; set; }

        public ICollection<CodeIssue> Issues { get; set; }
    }
}