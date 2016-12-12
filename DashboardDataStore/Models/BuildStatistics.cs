using System;
using System.Collections.Generic;

namespace DashboardDataStore.Models
{
    [Serializable]
    public class BuildStatistics
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public string Agent { get; set; }

        public double Duration { get; set; }

        public CodeCoverage Coverage { get; set; }

        public CodeInspection Inspection { get; set; }

        public int TestsTotal { get; set; }

        public int TestsFailed { get; set; }

        public ICollection<BenchmarkReport> BenchmarkReports { get; set; }
    }
}