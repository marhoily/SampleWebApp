using System;

namespace DashboardDataStore.Models
{
    [Serializable]
    public class Benchmark
    {
        public string Type { get; set; }

        public string Method { get; set; }

        public double Minimum { get; set; }

        public double Maximum { get; set; }

        public double Median { get; set; }
    }
}