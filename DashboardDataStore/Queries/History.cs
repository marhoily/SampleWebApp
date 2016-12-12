using System.Collections.Generic;
using System.Linq;
using DashboardDataStore.Models;

namespace DashboardDataStore.Queries
{
    public class History
    {
        private readonly IEnumerable<BuildStatistics> _builds;

        public History(IEnumerable<BuildStatistics> builds)
        {
            _builds = builds.ToArray();
        }

        public IEnumerable<BuildMetric<int>> TestsTotal => _builds
            .Where(b => b.Name == "Continuous")
            .Select(b => new BuildMetric<int> { BuildNumber = b.Number, Value = b.TestsTotal });

        public IEnumerable<BuildMetric<int>> TestsFailed => _builds
            .Where(b => b.Name == "Continuous")
            .Select(b => new BuildMetric<int> { BuildNumber = b.Number, Value = b.TestsFailed });

        public IEnumerable<BuildMetric<double>> BuildDuration => _builds
            .Where(b => b.Name == "Continuous")
            .Select(b => new BuildMetric<double> { BuildNumber = b.Number, Value = b.Duration });

        public IEnumerable<BuildMetric<int>> Coverage => _builds
            .Where(b => b.Name == "Nightly")
            .Select(b => new BuildMetric<int> { BuildNumber = b.Number, Value = b.Coverage.CoveredStatements / b.Coverage.TotalStatements * 100 });

        public IEnumerable<BuildMetric<int>> CodeIssues => _builds
            .Where(b => b.Name == "Nightly")
            .Select(b => new BuildMetric<int> { BuildNumber = b.Number, Value = b.Inspection.Issues.Count });

        public IEnumerable<BuildMetric<double>> EventPlayerSetBenchmarks => _builds
            .Where(b => b.Name == "Nightly")
            .Select(b => new BuildMetric<double> { BuildNumber = b.Number, Value = b.BenchmarkReports.Single(r => r.Title == "EventPlayer").Benchmarks.Single(mb => mb.Method == "SetBenchmark").Median });

        public IEnumerable<BuildMetric<double>> EventPlayerResetBenchmarks => _builds
            .Where(b => b.Name == "Nightly")
            .Select(b => new BuildMetric<double> { BuildNumber = b.Number, Value = b.BenchmarkReports.Single(r => r.Title == "EventPlayer").Benchmarks.Single(mb => mb.Method == "ResetBenchmark").Median });

        public IEnumerable<BuildMetric<double>> EventPlayerAddBenchmarks => _builds
            .Where(b => b.Name == "Nightly")
            .Select(b => new BuildMetric<double> { BuildNumber = b.Number, Value = b.BenchmarkReports.Single(r => r.Title == "EventPlayer").Benchmarks.Single(mb => mb.Method == "AddBenchmark").Median });

        public IEnumerable<BuildMetric<double>> EventPlayerRemoveBenchmarks => _builds
            .Where(b => b.Name == "Nightly")
            .Select(b => new BuildMetric<double> { BuildNumber = b.Number, Value = b.BenchmarkReports.Single(r => r.Title == "EventPlayer").Benchmarks.Single(mb => mb.Method == "RemoveBenchmark").Median });
    }
}