using ValuationBackend.Models;

namespace ValuationBackend.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Ensure DB is created
            context.Database.EnsureCreated();

            // Initialize Rating Requests
            InitializeRatingRequests(context);

            // Initialize Land Miscellaneous Master Files
            InitializeLandMiscellaneousMasterFiles(context);
        }

        private static void InitializeRatingRequests(AppDbContext context)
        {
            // If there's any data, stop
            if (context.RatingRequests.Any())
                return;

            // Add dummy records
            var requests = new RatingRequest[]
            {
                new RatingRequest
                {
                    RequestType = "Mass Rating",
                    RatingReferenceNo = "MR-001",
                    LocalAuthority = "Colombo MC",
                    YearOfRevision = 2022,
                    Status = "Pending"
                },
                new RatingRequest
                {
                    RequestType = "Rating Assessment",
                    RatingReferenceNo = "RA-001",
                    LocalAuthority = "Galle MC",
                    YearOfRevision = 2023,
                    Status = "Approved"
                },
                new RatingRequest
                {
                    RequestType = "Rating Building",
                    RatingReferenceNo = "RB-001",
                    LocalAuthority = "Kandy UC",
                    YearOfRevision = 2021,
                    Status = "Rejected"
                }
            };

            context.RatingRequests.AddRange(requests);
            context.SaveChanges();
        }


        private static void InitializeLandMiscellaneousMasterFiles(AppDbContext context)
        {
            // If there's any data, stop
            if (context.LandMiscellaneousMasterFiles.Any())
                return;

            // Add dummy records
            var masterFiles = new LandMiscellaneousMasterFile[]
            {
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52412,
                    PlanType = "Survey Plan",
                    PlanNo = "SP-2023-001",
                    RequestingAuthorityReferenceNo = "001",
                    Status = "Success",
                    Source = "https://example.com/plans/SP-2023-001"
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52413,
                    PlanType = "Block Survey",
                    PlanNo = "BS-2023-045",
                    RequestingAuthorityReferenceNo = "002",
                    Status = "Pending",
                    Source = "https://example.com/plans/BS-2023-045"
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52414,
                    PlanType = "Preliminary Plan",
                    PlanNo = "PP-2022-123",
                    RequestingAuthorityReferenceNo = "003",
                    Status = "Success",
                    Source = "https://example.com/plans/PP-2022-123"
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52415,
                    PlanType = "Final Village Plan",
                    PlanNo = "FVP-2021-078",
                    RequestingAuthorityReferenceNo = "004",
                    Status = "Rejected",
                    Source = "https://example.com/plans/FVP-2021-078"
                },
                new LandMiscellaneousMasterFile
                {
                    MasterFileNo = 52416,
                    PlanType = "Topographical Survey",
                    PlanNo = "TS-2023-099",
                    RequestingAuthorityReferenceNo = "005",
                    Status = "Success",
                    Source = "https://example.com/plans/TS-2023-099"
                }
            };

            context.LandMiscellaneousMasterFiles.AddRange(masterFiles);
            context.SaveChanges();
        }
    }
}