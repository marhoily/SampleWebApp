using System.Data.Entity;

namespace DashboardDataStore.Data
{
    public class Context : DbContext
    {
        public Context()
        {
            this.Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<DataEntry>()
                .Map(cfg => cfg.ToTable("Data"))
                .HasKey(d => d.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}