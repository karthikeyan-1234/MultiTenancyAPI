using DemoApplicationAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace DemoApplicationAPI
{
    public class AppDBContext:DbContext
    {
        private ITenantResolver tenantResolver;
        public DbSet<TestTable> TestTables { get; set; }

        public AppDBContext(DbContextOptions options, ITenantResolver tenantResolver): base(options)
        {
            this.tenantResolver = tenantResolver;
            var connectionString = tenantResolver.GetConnectionString();
            Database.SetConnectionString(connectionString);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var testTables = modelBuilder.Entity<TestTable>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
