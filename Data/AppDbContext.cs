using Microsoft.EntityFrameworkCore;
using ValuationBackend.Models;

namespace ValuationBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RatingRequest> RatingRequests { get; set; }

        public DbSet<LandMiscellaneousMasterFile> LandMiscellaneousMasterFiles { get; set; }
        
        public DbSet<Report> Reports { get; set; }
        
        public DbSet<InspectionReport> InspectionReports { get; set; }
        
        public DbSet<InspectionBuilding> InspectionBuildings { get; set; }
    }
}