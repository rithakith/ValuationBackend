using Microsoft.EntityFrameworkCore;
using ValuationBackend.Models;

namespace ValuationBackend.Data
{
    public class ValuationContext : DbContext
    {
        public ValuationContext(DbContextOptions<ValuationContext> options) : base(options) { }

        public DbSet<DecisionField> DecisionFields { get; set; }
        // ...add other DbSets as needed...
    }
}
