using System.Collections.Generic;
using System.Linq;
using DashboardDataStore.Models;
using Newtonsoft.Json;

namespace DashboardDataStore.Data
{
    public static class ContextExtensions
    {
        public static void Add(this Context self, BuildStatistics model)
        {
            self.Set<DataEntry>().Add(new DataEntry {Content = JsonConvert.SerializeObject(model)});
        }

        public static IEnumerable<BuildStatistics> Get(this Context self)
        {
            return self.Set<DataEntry>().ToArray().Select(de => JsonConvert.DeserializeObject<BuildStatistics>(de.Content));
        }
    }
}