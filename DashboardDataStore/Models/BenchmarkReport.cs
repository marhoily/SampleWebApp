using System;
using System.Collections.Generic;

namespace BuildStatisticsServices.Models
{
    [Serializable]
    public class BenchmarkReport
    {
        public string Title { get; set; }

        public ICollection<Benchmark> Benchmarks { get; set; }
    }
}