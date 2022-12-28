using Microsoft.EntityFrameworkCore;
using DecisionCloud.Model;

namespace DecisionCloud.Data
{
    public class BrandStoreContext : DbContext
    {
        public BrandStoreContext(DbContextOptions<BrandStoreContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<BrandModel> Brands { get; set; }
    }
}