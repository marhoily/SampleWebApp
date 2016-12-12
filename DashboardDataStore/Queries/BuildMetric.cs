namespace DashboardDataStore.Queries
{
    public class BuildMetric<T>
    {
        public int BuildNumber { get; set; }

        public T Value { get; set; }
    }
}