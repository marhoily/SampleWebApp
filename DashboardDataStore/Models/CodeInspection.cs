using System;
using System.Collections.Generic;

namespace DashboardDataStore.Models
{
    [Serializable]
    public class CodeInspection : List<CodeIssueType>
    {
        public ICollection<CodeIssueType> IssueTypes { get; set; }

        public ICollection<CodeIssue> Issues { get; set; }
    }
}