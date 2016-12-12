using System;

namespace DashboardDataStore.Models
{
    [Serializable]
    public class CodeCoverage
    {
        public int TotalStatements { get; set; }

        public int CoveredStatements { get; set; }
    }
}