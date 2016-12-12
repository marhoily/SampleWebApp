using System;

namespace DashboardDataStore.Models
{
    [Serializable]
    public class CodeIssue
    {
        public string TypeId { get; set; }

        public string File { get; set; }

        public int Line { get; set; }

        public string Message { get; set; }
    }
}