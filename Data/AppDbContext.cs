using Microsoft.EntityFrameworkCore;
using ValuationBackend.Models;
using ValuationBackend.Models.iteration2;

namespace ValuationBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<RatingRequest> RatingRequests { get; set; }

        public DbSet<LandMiscellaneousMasterFile> LandMiscellaneousMasterFiles { get; set; }

        public DbSet<Reconciliation> Reconciliations { get; set; }

        public DbSet<AssetNumberChange> AssetNumberChanges { get; set; }

        public DbSet<AssetDivision> AssetDivisions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTask> UserTasks { get; set; }

        public DbSet<MasterDataItem> MasterDataItems { get; set; }

        public DbSet<ImageData> ImageData { get; set; }

        public DbSet<LandAquisitionMasterFile> LandAquisitionMasterFiles { get; set; }

        public DbSet<LALot> LALots { get; set; }

        public DbSet<PastValuationsLACoordinate> PastValuationsLACoordinates { get; set; }
        public DbSet<BuildingRatesLACoordinate> BuildingRatesLACoordinates { get; set; }
        public DbSet<SalesEvidenceLACoordinate> SalesEvidenceLACoordinates { get; set; }
        public DbSet<RentalEvidenceLACoordinate> RentalEvidenceLACoordinates { get; set; }

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

        public DbSet<OfficesRatingCard> OfficesRatingCards { get; set; }

        public DbSet<ShopsRatingCard> ShopsRatingCards { get; set; }

        public DbSet<AgricultureRatingCard> AgricultureRatingCards { get; set; }

        public DbSet<SpecialRatingCard> SpecialRatingCards { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<PropertyCategory> PropertyCategories { get; set; }

        public DbSet<I2RentalEvidence> I2RentalEvidences { get; set; }

        public DbSet<DecisionField> DecisionFields { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity table names explicitly
            modelBuilder.Entity<RentalEvidenceLA>().ToTable("RentalEvidencesLA");
            modelBuilder.Entity<SalesEvidenceLA>().ToTable("SalesEvidencesLA");
            modelBuilder.Entity<Reconciliation>()
    .HasOne(r => r.Asset)
    .WithMany()
    .HasForeignKey(r => r.AssetId);

            // NEW: Configure LMRentalEvidence relationships
            modelBuilder.Entity<LMRentalEvidence>()
                .HasOne(lm => lm.LandMiscellaneousMasterFile)
                .WithMany()
                .HasForeignKey(lm => lm.LandMiscellaneousMasterFileId)
                .OnDelete(DeleteBehavior.SetNull);

            // NEW: Add index for performance
            modelBuilder.Entity<LMRentalEvidence>()
                .HasIndex(lm => lm.LandMiscellaneousMasterFileId)
                .HasDatabaseName("IX_LMRentalEvidence_LandMiscellaneousMasterFileId");

            // Configure LMBuildingRates relationships
            modelBuilder.Entity<LMBuildingRates>()
                .HasOne(lm => lm.LandMiscellaneousMasterFile)
                .WithMany() // No navigation property on master file side
                .HasForeignKey(lm => lm.LandMiscellaneousMasterFileId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<LMBuildingRates>()
                .HasIndex(lm => lm.LandMiscellaneousMasterFileId)
                .HasDatabaseName("IX_LMBuildingRates_LandMiscellaneousMasterFileId");

            // Configure LMPastValuation relationships
            modelBuilder.Entity<LMPastValuation>()
                .HasOne(lm => lm.LandMiscellaneousMasterFile)
                .WithMany() // No navigation property on master file side
                .HasForeignKey(lm => lm.LandMiscellaneousMasterFileId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<LMPastValuation>()
                .HasIndex(lm => lm.LandMiscellaneousMasterFileId)
                .HasDatabaseName("IX_LMPastValuation_LandMiscellaneousMasterFileId");

            // Configure LMSalesEvidence relationships
            modelBuilder.Entity<LMSalesEvidence>()
                .HasOne(lm => lm.LandMiscellaneousMasterFile)
                .WithMany() // No navigation property on master file side
                .HasForeignKey(lm => lm.LandMiscellaneousMasterFileId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<LMSalesEvidence>()
                .HasIndex(lm => lm.LandMiscellaneousMasterFileId)
                .HasDatabaseName("IX_LMSalesEvidence_LandMiscellaneousMasterFileId");

            // Configure I2RentalEvidence relationships
            modelBuilder.Entity<I2RentalEvidence>()
                .HasOne(i2 => i2.Asset)
                .WithMany()
                .HasForeignKey(i2 => i2.AssetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<I2RentalEvidence>()
                .HasIndex(i2 => i2.AssetId)
                .HasDatabaseName("IX_I2RentalEvidence_AssetId");
        }
    }
}
