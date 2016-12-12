using System;
using System.Collections.Generic;

namespace DashboardDataStore.Models
{
    [Serializable]
    public class BenchmarkReport
    {
        public string Title { get; set; }

        public ICollection<Benchmark> Benchmarks { get; set; }
    }
}