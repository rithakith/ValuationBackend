using Microsoft.EntityFrameworkCore;
using ValuationBackend.Models;

namespace ValuationBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<RatingRequest> RatingRequests { get; set; }
        public DbSet<LandMiscellaneousMasterFile> LandMiscellaneousMasterFiles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTask> UserTasks { get; set; }

        public DbSet<MasterDataItem> MasterDataItems { get; set; }

        public DbSet<ImageData> ImageData { get; set; }

        public DbSet<LandAquisitionMasterFile> LandAquisitionMasterFiles { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<InspectionReport> InspectionReports { get; set; }

        public DbSet<InspectionBuilding> InspectionBuildings { get; set; }

        public DbSet<ConditionReport> ConditionReports { get; set; }

        public DbSet<RentalEvidenceLA> RentalEvidencesLA { get; set; }

        public DbSet<SalesEvidenceLA> SalesEvidencesLA { get; set; }

        public DbSet<BuildingRatesLA> BuildingRatesLA { get; set; }

        public DbSet<PastValuationsLA> PastValuationsLA { get; set; }

        public DbSet<LMRentalEvidence> LMRentalEvidences { get; set; }
        public DbSet<LMSalesEvidence> LMSalesEvidences { get; set; }
        public DbSet<LMPastValuation> LMPastValuations { get; set; }
        public DbSet<LMBuildingRates> LMBuildingRates { get; set; }

        public DbSet<RequestType> RequestTypes { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<DomesticRatingCard> DomesticRatingCards { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<PropertyCategory> PropertyCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity table names explicitly
            modelBuilder.Entity<RentalEvidenceLA>().ToTable("RentalEvidencesLA");
            modelBuilder.Entity<SalesEvidenceLA>().ToTable("SalesEvidencesLA");
        }
    }
}
