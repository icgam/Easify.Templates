using Easify.Ef;
using Easify.Http;
using Microsoft.EntityFrameworkCore;

namespace Template.Core.Data
{
    public sealed class AppDbContext : DbContextBase
    {
        public AppDbContext(DbContextOptions options, IOperationContext context) : base(options, context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Add the mappings here
        }
    }
}